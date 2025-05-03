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
    public GameObject OptionsUI;
    public GameObject FadeUI;
    public GameObject SkipButton;
    public DialogueManager dialogueManager;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        SkipButton.SetActive(false); // Hide the skip button at the start
        GameData.SavedScore = 0; // Reset the saved score at the start of the game
        PlayButton.interactable = false; //PlayButton is not interactable before fadein
        // Black screen on start, then fade in
        StartCoroutine(FadeInScene(2f));
        StartCoroutine(FadeSequence());
        OptionsUI.SetActive(false);
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
        audioManager.PlaySFX2(audioManager.playClickSFX);
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
        FadeUI.gameObject.SetActive(false); // Hide the fade image after fading out
    }
    IEnumerator FadeOutAndLoadScene(float duration)
    {
        FadeUI.gameObject.SetActive(true); // Show the fade image before fading out
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

        SkipButton.SetActive(true); // Show the skip button after fading out

        dialogueManager.StartDialogue(
            "A curious and brave girl ventures to investigate the glow on her own only to find an ancient power of destruction!\n\n" +
            "Suddenly, guardians of this power from the past appear and try to destroy her.\n\n" +
            "She has only one option and that is to fight!"
        );
    }

    public void SkipButtonPressed()
    {
        audioManager.PlaySFX2(audioManager.clickSFX);
        SceneManager.LoadScene("Level1"); // Load the scene directly when the skip button is pressed
    }

    public void LBbuttonPressed()
    {
        audioManager.PlaySFX2(audioManager.clickSFX);
        MenuScreenUI.SetActive(false);
        LeaderboardUI.SetActive(true);
        OptionsUI.SetActive(false);
        leaderboardManager.ShowLeaderboardUI();
        
    }

    public void OptionsbuttonPressed()
    {
        audioManager.PlaySFX2(audioManager.clickSFX);
        MenuScreenUI.SetActive(false);
        LeaderboardUI.SetActive(false);
        OptionsUI.SetActive(true);
        

    }

    public void BackButtonPressed()
    {
        audioManager.PlaySFX2(audioManager.clickSFX);
        MenuScreenUI.SetActive(true);
        LeaderboardUI.SetActive(false);
        OptionsUI.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting"); // This will only show in the editor, not in the built game
    }
}
