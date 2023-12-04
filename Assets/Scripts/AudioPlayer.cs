using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range (0f, 1f)]float shootingVol = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range (0f, 1f)]float explosionVol = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVol);
    }

    public void PlayExplodingClip()
    {
        PlayClip(explosionClip, explosionVol);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
