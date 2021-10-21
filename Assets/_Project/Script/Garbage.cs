using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] int scoreValue = 50;
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameStatus>().AddScore(scoreValue);
        //We thought that destroying the objects would make the application more tiring, so we closed their activities. 
        this.gameObject.SetActive(false);
    }
}
