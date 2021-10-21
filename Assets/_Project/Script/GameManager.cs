using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public FollowDrawRoad followDrawRoad = null;

    //we have control 
    private void Awake()
    {
        instance = this;
    }
}
