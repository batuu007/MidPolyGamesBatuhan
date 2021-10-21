using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deathScreen;

    [SerializeField] GameObject playerDeathVFX;

    private float deathTime = 3f;
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //We realized that you hit the obstacles and activated the deathscreen 
        if (collision.gameObject.tag == "Obstacle")
        {
            InvokeRepeating("Death", 3f, 1f); //We say how soon we will activate our screen method. 
            GameObject explosion = Instantiate(playerDeathVFX, transform.position, transform.rotation); // we start VFX
            Destroy(explosion, deathTime); //after a certain time we destroy our vfx 
            this.gameObject.SetActive(false); //We deactivate our object with vfx 
        }
    }

    public void RestartGame()
    {
        //we restarted the scene
        SceneManager.LoadScene(0);
        //when we restart the game we reset our score 
        FindObjectOfType<GameStatus>().ResetGame();
    }
    void Death()
    {
        deathScreen.SetActive(true);
    }
}
