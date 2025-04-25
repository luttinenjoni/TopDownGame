using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
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

    private void Start()
    {
        Time.timeScale = 1f; // Make sure the game is running at normal speed
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Menu")
        {
            return;
        }
        InitLevelUI();
    }


    public void InitLevelUI()
    {
        WinScreen.SetActive(false); //Hide WinScreen at start
        score = GameData.SavedScore; //Get the score from GameData
        SaveScoreUI.SetActive(false);
        UpdateEnemyText();
        scoreText.text = "Score: " + score;
    }

    public void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across levels
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void NewLevelInit()
    {

    }

    public void EnemyKilled()
    {
        if (level == 1) //If the level is 1, we will start the game with 12 enemies
        {
            enemyValue -= 1;
            EnemiesKilled += 1;
            UpdateEnemyText();

            if (enemyValue == 10) //Wave Two begins, when there are 9 alive enemies left
            {
                StartCoroutine(spawnManager.L1W2());
            }

            if (enemyValue == 5)
            {
                StartCoroutine(spawnManager.L1W3());
            }

            if (enemyValue <= 0) //If enemies left are 0, pause the game and show WinScreen
            {
                StartCoroutine(Victory(2f));
            }

        }

        if (level == 2)
        {
            enemyValue -= 1;
            EnemiesKilled += 1;
            UpdateEnemyText();

            if (enemyValue <= 0) //If enemies left are 0, pause the game and show WinScreen
            {
                StartCoroutine(Victory(2f));
            }

        }
    }

    IEnumerator Victory(float duration)
    {
        isRunning = false;
        Time.timeScale = 0f; // Pause the game
        yield return new WaitForSecondsRealtime(duration); // Wait for the specified duration
        WinScreen.gameObject.SetActive(true);
        WinStats();
        SaveScoreUI.gameObject.SetActive(true);
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }
    public void UpdateEnemyText()
    {
        enemyCounter.text = "Enemies left: " + enemyValue;
    }

    public void NextButtonPressed()
    {
        WinScreen.SetActive(false);
        Time.timeScale = 1f; // Varmistetaan, että peli jatkuu normaalisti
        level += 1; //Seuraavaan kenttään
        NewLevelInit();
        SceneManager.LoadScene(NextLevel); // Ladataan seuraava kenttä
    }



    public void MenuButtonPressed()
    {

        Debug.Log("Nappia painettu");
        StartCoroutine(FadeOutAndLoad(2f));
    }

    IEnumerator FadeOutAndLoad(float duration)
    {
    // Pidä peli pausella, kunnes fade on valmis
    float elapsed = 0f;
    Color color = BlackFade.color;
    color.a = 0f;
    BlackFade.color = color;

    while (elapsed < duration)
    {
        color.a = Mathf.Lerp(0f, 1f, elapsed / duration);
        BlackFade.color = color;
        elapsed += Time.unscaledDeltaTime; // Käytetään unscaledDeltaTimea, jotta animointi ei vaikuta Time.timeScale
        yield return null;
    }

    color.a = 1f;
    BlackFade.color = color;
    SceneManager.LoadScene(MenuLoad);

    // Varmistetaan, että peli jatkuu normaalisti
    // Tämä on viimeinen kohta, missä Time.timeScale asetetaan takaisin 1
    Time.timeScale = 1f;
    }



    public void StartTimer()
    {
        timer = 0f;
        isRunning = true;
    }

    public void WinStats()
    {

        SaveScoreUI.SetActive(true);
        isRunning = false;
        float WinTime = timer;
        TimeText.text = "Time passed: " + WinTime.ToString("F1");
        float TimePoints = 2400 - Mathf.Round(timer * 10f);
        TimeScore.text = TimePoints.ToString("F0");

        KillText.text = "Enemies killed: " + EnemiesKilled;
        float KillPoints = EnemiesKilled * 100;
        KillScore.text = KillPoints.ToString("F0"); //KillScore -teksti, näyttää kuinka monta pistettä tapoista saa.

        HealthScript playerHealth = player.gameObject.GetComponent<HealthScript>();
        int HPleft = playerHealth.CurrentHealth();
        HPText.text = "HP left: " + HPleft.ToString();
        float HPPoints = HPleft * 200;
        HPScore.text = HPPoints.ToString();

        GunMovement playerWeapon = player.transform.Find("Triangle").GetComponent<GunMovement>();

        int FiresHit = playerWeapon.FiresHit;
        int FiresShot = playerWeapon.FiresShot;
        float Accuracy = (float)FiresHit / FiresShot * 100;
        Accuracy = (int)Accuracy;
        int AccuracyPoints = (int)(2000 / 100f * Accuracy);
        AccuracyText.text = "Accuracy: " + Accuracy + "%";
        AccuracyScore.text = AccuracyPoints.ToString("F0");


        float TotalPoints = TimePoints + HPPoints + AccuracyPoints + score;
        TotalScore.text = "Total score: " + TotalPoints.ToString("F0");

        score = (int)TotalPoints; //Päivitetään ScoreManagerin score muuttuja, jotta se voidaan tallentaa leaderboardille
        GameData.SavedScore += score;
    }
}
