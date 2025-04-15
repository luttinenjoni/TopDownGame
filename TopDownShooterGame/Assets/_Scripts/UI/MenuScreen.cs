using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UIElements;

public class MenuScreen : MonoBehaviour
{
    public UnityEngine.UI.Image fadeImage;
    public string sceneToLoad; // Scene name set in Inspector
    public TextFader textFader;
    public UnityEngine.UI.Button PlayButton;
    public LeaderboardManager leaderboardManager;
    public GameObject MenuScreenUI;
    public GameObject LeaderboardUI;

    void Start()
    {
        PlayButton.interactable = false; //PlayButton is not interactable before fadein
        // Black screen on start, then fade in
        StartCoroutine(FadeInScene(2f));
        StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        // Call the FadeInText coroutine
        yield return StartCoroutine(textFader.FadeInText(1f));

        // Wait for 4 seconds
        yield return new WaitForSeconds(3f);

        // Call the FadeOutText coroutine
        yield return StartCoroutine(textFader.FadeOutText(1f));
    }

    public void OnFadeOutButtonPressed()
    {
        // Call this from a UI Button
        StartCoroutine(FadeOutAndLoadScene(2f));
    }

    IEnumerator FadeInScene(float duration)
    {
        yield return new WaitForSeconds(5); //Wait for a while while the text fades in and stays there
        float elapsed = 0f;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(1f, 0f, elapsed / duration);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
        PlayButton.interactable = true; //PlayButton is interactable after fadein
    }

    IEnumerator FadeOutAndLoadScene(float duration)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsed / duration);
            fadeImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        // Load the next scene
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LBbuttonPressed()
    {
        MenuScreenUI.SetActive(false);
        LeaderboardUI.SetActive(true);
        leaderboardManager.ShowLeaderboardUI();
    }

    public void BackButtonPressed()
    {
        MenuScreenUI.SetActive(true);
        LeaderboardUI.SetActive(false);
        
    }
}
