using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu; // Reference to your pause menu UI panel
    // Update is called once per frame
    void Update()
    {
        // Check if the "R" key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the game by reloading the current scene
            Time.timeScale = 1f; // Set time scale to normal (unpause)
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        // Check if the "Escape" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // Resume the game
                Time.timeScale = 1f; // Set time scale to normal (unpause)
                isPaused = false;
                pauseMenu.SetActive(false); // Hide the pause menu
            }
            else
            {
                // Pause the game
                Time.timeScale = 0f; // Set time scale to zero (pause)
                isPaused = true;
                pauseMenu.SetActive(true); // Show the pause menu
            }
        }
    }

    
}