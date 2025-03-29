using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false); // Hide Game Over UI at start
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Show Game Over UI
        Time.timeScale = 0f; // Pause the game
    }
}
