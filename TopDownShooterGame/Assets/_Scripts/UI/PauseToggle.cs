using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; // Assign your pause menu UI in the Inspector

    void Start()
    {
        // Initialize the game state
        isPaused = false;
        pauseMenuUI.SetActive(false); // Hide pause menu UI at the start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true); // Show pause menu UI
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("Game Resumed");
            pauseMenuUI.SetActive(false); // Hide pause menu UI
        }
    }
}