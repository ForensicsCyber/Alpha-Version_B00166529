using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene reloading

public class GameOverHandler : MonoBehaviour
{
    public GameObject player;        // Reference to the Player GameObject
    public GameObject gameOverUI;    // Reference to the GameOver UI
    public float fallThreshold = -10f; // The Y position threshold for game over

    void Update()
    {
        // Check if the player's position falls below the threshold
        if (player.transform.position.y < fallThreshold)
        {
            ActivateGameOver();
        }
    }

    private void ActivateGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Activate the Game Over UI
            Time.timeScale = 0f;       // Pause the game
        }
    }

    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
