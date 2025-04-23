using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float letterDelay = 0.05f;
    private string sceneToLoad; // Scene name set in Inspector
    private Coroutine typingCoroutine;

    public void Start()
    {
    }

    public void StartDialogue(string sentence)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
{
    dialogueText.text = "";
    foreach (char letter in sentence)
    {
        dialogueText.text += letter;
        yield return new WaitForSeconds(letterDelay);
    }

    // Only wait 2 seconds after it's done typing
    yield return new WaitForSeconds(2f);

    SceneManager.LoadScene("Level1");
}
}
