using System.IO;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SaveScore : MonoBehaviour
{
    public ScoreManager scoreManager;
    private int score;
    private string playerName;
    public TMP_InputField playerNameInput;
    public LeaderboardManager leaderboardManager;
    private bool pressed = false;

    void Start()
    {
        scoreManager = ScoreManager.Instance; // Get the ScoreManager instance
        score = scoreManager.score;
        playerName = playerNameInput.text;
    }

    public void SaveButtonPressed()
    {
        if (pressed == false)
        {
            pressed = true;
            playerName = playerNameInput.text;
            score = scoreManager.score;
            leaderboardManager.AddScore(playerName, score);
            Debug.Log("Score saved: " + playerName + ": " + score);
        }
        else
        {
            return;
        }
        
    }
}