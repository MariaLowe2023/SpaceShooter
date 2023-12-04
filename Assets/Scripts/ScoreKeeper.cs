using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentscore;


    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
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

    public int GetCurrentScore()
    {
        return currentscore;
    }

    public void ModifyScore(int value)
    {
        currentscore += value;
        Mathf.Clamp(currentscore, 0, int.MaxValue);
        Debug.Log(currentscore);
    }

    public void ResetScore()
    {
        currentscore = 0;
    }



}
