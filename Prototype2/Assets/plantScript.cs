using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantScript : MonoBehaviour
{
    public GameObject fire;
    public GameObject flower;
    public AudioSource audioPlayer;

    public float minInterval = 2.0f;
    public float maxInterval = 7.0f;
    public float minDelay = 2f;
    public float maxDelay = 5f;
    public float dyingPlantTime = 2.0f;

    public float minSpawnX = -5f; // Minimum X coordinate for spawning
    public float maxSpawnX = 5f;  // Maximum X coordinate for spawning
    public float minSpawnY = -3f; // Minimum Y coordinate for spawning
    public float maxSpawnY = 3f;  // Maximum Y coordinate for spawning

    private void Start()
    {
        StartCoroutine(RandomDyingPlant());

    }

    private IEnumerator RandomDyingPlant()
    {
        // Start the coroutine to randomly toggle the fire image

        while (true)
        {
            // Disable the fire image (hide it)
            fire.SetActive(false);

            // Wait for a random time interval
            float randomInterval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomInterval);

            // Calculate a random spawn position within the specified range
            float randomX = Random.Range(minSpawnX, maxSpawnX);
            float randomY = Random.Range(minSpawnY, maxSpawnY);

            // Set the object's position to the random spawn position
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            flower.transform.position = spawnPosition;
            fire.transform.position = spawnPosition;
            // Enable the fire image (make it appear)
            fire.SetActive(true);


            //// Wait 2 seconds
            yield return new WaitForSeconds(dyingPlantTime);

            if (fire.activeSelf)
            {
                PlayerLives Lives = FindObjectOfType<PlayerLives>();

                if (Lives != null)
                {
                    Lives.LoseLife();
                    if(Lives.getCurrLives() <= 0)
                    {
                        yield break;
                    }
                }
            }

            // Disable the fire image again 
            fire.SetActive(false);

            // Wait for another random time interval before the next appearance
            randomInterval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomInterval);
     
            
        }
    }

    //when character collides with dryplant 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && fire.activeSelf)
        {
            audioPlayer.Play();
            
            //fake water plant here and return flower back to original color
            fire.SetActive(false);
        }
    }

    }
