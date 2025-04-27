using System.IO;
using UnityEngine;
using System.Collections;
using TMPro;

public class SaveScore : MonoBehaviour
{
    public ScoreManager scoreManager;
    private int score;
    private string playerName;
    public TMP_InputField playerNameInput;
    public LeaderboardManager leaderboardManager;
    private bool pressed = false;
    public TextMeshProUGUI scoreText2;


    void Start()
    {
        // Safety check for ScoreManager initialization
        if (scoreManager == null)
        {
            scoreManager = ScoreManager.Instance;
            if (scoreManager == null)
            {
                Debug.LogError("ScoreManager is still not initialized!");
                return; // Don't proceed if ScoreManager is not found
            }
        }

        score = scoreManager.score;

        // Display the score if you have a UI element for it
        if (scoreText2 != null)
        {
            scoreText2.text = "Score: " + score.ToString();
        }
    }

    public void SaveButtonPressed()
    {
        if (pressed == false)
        {
            pressed = true;
            playerName = playerNameInput.text;
            score = ScoreManager.Instance.score;
            leaderboardManager.AddScore(playerName, score);
            Debug.Log("Score saved: " + playerName + ": " + score);
        }
        else
        {
            return;
        }
        
    }
}