using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; // Assign your pause menu UI in the Inspector
    public GameObject OptionsUI;
    public PlayerMovement player; // Reference to the Player script

    void Start()
    {
        OptionsUI.SetActive(false); // Hide options UI at the start
        // Initialize the game state
        isPaused = false;
        pauseMenuUI.SetActive(false); // Hide pause menu UI at the start
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (player.alive == true)
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
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
    public void OptionsPressed()
    {
        OptionsUI.SetActive(true); // Show options UI
        pauseMenuUI.SetActive(false); // Hide pause menu UI
    }

    public void BackToPauseMenu()
    {
        OptionsUI.SetActive(false); // Hide options UI
        pauseMenuUI.SetActive(true); // Show pause menu UI
    }
}