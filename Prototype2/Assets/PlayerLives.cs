using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private int Lives = 3;
    private int currentLives;

    public GameObject LOSE;

    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;

    public AudioSource audioPlayer;
    //public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //gameOverCanvas.SetActive(false);
        LOSE.SetActive(false);
        currentLives = Lives;
    }

   public void LoseLife()
    {
        currentLives--;
        audioPlayer.Play();
        if (currentLives == 2)
        {
            heart_3.SetActive(false);


        }
        if(currentLives == 1)
        {
            heart_2.SetActive(false);
        }

        if(currentLives <= 0)
        {
            heart_1.SetActive(false);
            Debug.Log("No More Lives. Game Over.");
            //gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
            LOSE.SetActive(true);
            //Application.Quit();
        }
    }

    public int getCurrLives()
    {
        return currentLives;
    }
}
