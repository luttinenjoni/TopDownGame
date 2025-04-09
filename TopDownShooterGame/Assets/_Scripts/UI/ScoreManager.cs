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
    private int score = 0;
     public SpawnManager spawnManager;

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

        if (enemyValue == 9) //Wave Two begins, when there are 9 alive enemies left
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
            WinScreen.SetActive(true);
        }
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
}
