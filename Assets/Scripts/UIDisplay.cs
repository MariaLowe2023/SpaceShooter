using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext;
    ScoreKeeper scoreKeeper;


    [SerializeField] Slider healthbar;
    [SerializeField] Health playerHealth;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthbar.maxValue = playerHealth.GetCurrentHealth();
    }

    void Update()
    {
        scoretext.text = scoreKeeper.GetCurrentScore().ToString();
        healthbar.value = playerHealth.GetCurrentHealth();
    }




}
