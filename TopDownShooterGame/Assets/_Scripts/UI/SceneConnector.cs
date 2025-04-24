using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneUIConnector : MonoBehaviour
{
    public int enemyValue = 12;
    public UnityEngine.UI.Image BlackFade;
    public TextMeshProUGUI enemyCounter;
    public TextMeshProUGUI scoreText;
    public GameObject WinScreen;
    public string MenuLoad;
    public string NextLevel;
    public int level = 1;
    public int EnemiesKilled = 0;
    public int score = 0;
    public SpawnManager spawnManager;
    public OrbScript orbScript;

    public float timer = 0f;
    public bool isRunning = false;

    public GunMovement weaponScript;
    public Transform player;
    public GameObject SaveScoreUI;


    //Next, we will "import" all the texts needed for the WinStats
    public TextMeshProUGUI KillText;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI AccuracyText;
    public TextMeshProUGUI KillScore;
    public TextMeshProUGUI TimeScore;
    public TextMeshProUGUI HPScore;
    public TextMeshProUGUI AccuracyScore;
    public TextMeshProUGUI TotalScore;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.enemyValue = enemyValue;
            ScoreManager.Instance.BlackFade = BlackFade;
            ScoreManager.Instance.scoreText = scoreText;
            ScoreManager.Instance.enemyCounter = enemyCounter;
            ScoreManager.Instance.WinScreen = WinScreen;
            ScoreManager.Instance.MenuLoad = MenuLoad;
            ScoreManager.Instance.NextLevel = NextLevel;
            ScoreManager.Instance.level = level;
            ScoreManager.Instance.EnemiesKilled = EnemiesKilled;
            ScoreManager.Instance.score = score;
            ScoreManager.Instance.spawnManager = spawnManager;
            ScoreManager.Instance.orbScript = orbScript;
            ScoreManager.Instance.timer = timer;
            ScoreManager.Instance.isRunning = isRunning;
            ScoreManager.Instance.weaponScript = weaponScript;
            ScoreManager.Instance.player = player;
            ScoreManager.Instance.SaveScoreUI = SaveScoreUI;
            ScoreManager.Instance.KillText = KillText;
            ScoreManager.Instance.TimeText = TimeText;
            ScoreManager.Instance.HPText = HPText;
            ScoreManager.Instance.AccuracyText = AccuracyText;
            ScoreManager.Instance.KillScore = KillScore;
            ScoreManager.Instance.TimeScore = TimeScore;
            ScoreManager.Instance.HPScore = HPScore;
            ScoreManager.Instance.AccuracyScore = AccuracyScore;
            ScoreManager.Instance.TotalScore = TotalScore;

            ScoreManager.Instance.UpdateEnemyText();
            ScoreManager.Instance.InitLevelUI();
        }

        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level2" || currentScene == "Level3")
        {
            isRunning = true; // Start the timer if the scene is Level2 or Level3
            ScoreManager.Instance.isRunning = true; // Start the timer in ScoreManager
        }
    }
}
