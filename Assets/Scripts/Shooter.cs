using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header ("General Settings")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float basefiringRate = 5f;

    [Header("AI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minfiringRate = 0.1f;

    [SerializeField] bool useAi;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAi)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                              transform.position, 
                                              Quaternion.identity);

            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timetonextProjectile = Random.Range(basefiringRate - firingRateVariance,
                                            basefiringRate + firingRateVariance);
            timetonextProjectile = Mathf.Clamp(timetonextProjectile, minfiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timetonextProjectile);
        }
    }
}