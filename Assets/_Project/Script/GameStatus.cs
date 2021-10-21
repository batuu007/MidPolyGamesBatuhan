using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        SetUpSingletonScore(); // we implement singleton
    }

    private void SetUpSingletonScore()
    {
        int scoreCount = FindObjectsOfType(GetType()).Length;
        if (scoreCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        //we freeze it back to print the score
        return score;
    }
    public void AddScore(int scoreValue)
    {
        //We are adding the sum score to the total score 
        score += scoreValue; 
    }
    public void ResetGame()
    {
        //We reset to reset the score we achieved after losing 
        Destroy(gameObject);
    }
}
