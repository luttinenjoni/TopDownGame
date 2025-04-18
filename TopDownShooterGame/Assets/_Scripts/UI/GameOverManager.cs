using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public UnityEngine.UI.Image RedFade;
    public UnityEngine.UI.Image BlackFade;
    public GameObject gameOverPanel;
    public GameObject GameOverUI;
    public string MenuSceneLoad;
    public string NextLevel;
    public GameObject WinScreen;

    public TextMeshProUGUI ScoreText;
    public ScoreManager scoreManager;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Color color = BlackFade.color;
        color.a = 0f;
        BlackFade.color = color; //BLackFade muuttuu näkymättömäksi

        GameOverUI.SetActive(false);
        gameOverPanel.SetActive(false); // Hide Game Over UI at start
    }


    public float fadeDuration = 2f;
    public float maxFadeAlpha = 0.75f; // 0 = invisible, 1 = fully visible

    public IEnumerator ShowGameOver()
    {
        int score = scoreManager.score;
        audioSource.Play();
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1);

        ScoreText.text = "YOUR SCORE: " + score;

        gameOverPanel.SetActive(true);
        GameOverUI.SetActive(false);

        Color color = RedFade.color;
        color.a = 0f;
        RedFade.color = color;

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            color.a = Mathf.Lerp(0f, maxFadeAlpha, elapsed / fadeDuration);
            RedFade.color = color;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        // Snap to final value just in case
        color.a = maxFadeAlpha;
        RedFade.color = color;

        GameOverUI.SetActive(true);

    }

    public void NextButtonPressed()
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f; // Varmistetaan, että peli jatkuu normaalisti
        SceneManager.LoadScene(NextLevel); // Ladataan seuraava kenttä
    }

    public void MenuButtonPressed()
    {
        BlackFade.gameObject.SetActive(true);
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

    // Ladataan seuraava kohtaus
    // Tässä vaiheessa Time.timeScale on edelleen 0
    // Pysytään pausella, kunnes kohtaus ladataan
    SceneManager.LoadScene(MenuSceneLoad);

    // Varmistetaan, että peli jatkuu normaalisti
    // Tämä on viimeinen kohta, missä Time.timeScale asetetaan takaisin 1
    Time.timeScale = 1f;
    }

}