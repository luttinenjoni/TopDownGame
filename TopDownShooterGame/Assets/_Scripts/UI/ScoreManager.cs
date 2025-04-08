using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int enemyValue = 10;
    public TextMeshProUGUI enemyCounter;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        UpdateEnemyText();
        scoreText.text = "Score: " + score;
    }

    private void Awake()
    {
        // Singleton pattern to ensure only one ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyKilled()
    {
        enemyValue -= 1;
        UpdateEnemyText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }
    private void UpdateEnemyText()
    {
        enemyCounter.text = "Enemies left: " + enemyValue;
    }
}
