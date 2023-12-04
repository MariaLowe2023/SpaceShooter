using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endscore;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        endscore.text = "You Scored:\n" + scoreKeeper.GetCurrentScore();
    }
}
