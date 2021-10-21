using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    GameStatus gameStatus;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameStatus = FindObjectOfType<GameStatus>();
    }
    void Update()
    {
        scoreText.text = gameStatus.GetScore().ToString(); //we print our score on the screen 
    }
}
