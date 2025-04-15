using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
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
    public string sceneToLoad;
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
        EnemiesKilled += 1;
        UpdateEnemyText();

        if (enemyValue == 10) //Wave Two begins, when there are 9 alive enemies left
        {
            StartCoroutine(spawnManager.WaveTwo());
        }

        if (enemyValue == 5)
        {
            StartCoroutine(spawnManager.WaveThree());
        }

        if (enemyValue <= 0) //If enemies left are 0, pause the game and show WinScreen
        {
            Time.timeScale = 0f;
            StartCoroutine(VictoryWait(2f));
        }
    }

    private IEnumerator VictoryWait(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = 0f;
        WinScreen.SetActive(true);
        WinStats();
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

    public void NextButtonPressed()
    {
        WinScreen.SetActive(false);
        SaveScoreUI.SetActive(true);
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
    SceneManager.LoadScene(sceneToLoad);

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


        float TotalPoints = TimePoints + KillPoints + HPPoints + AccuracyPoints;
        TotalScore.text = "Total score: " + TotalPoints.ToString("F0");

        score = (int)TotalPoints; //Päivitetään ScoreManagerin score muuttuja, jotta se voidaan tallentaa leaderboardille
    }
}
