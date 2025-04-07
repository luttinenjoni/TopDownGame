using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextFader : MonoBehaviour
{
    public TMP_Text presentationText; // The Text to fade in/out

    // Fade the text in
    public IEnumerator FadeInText(float duration)
    {
        float elapsed = 0f;
        Color color = presentationText.color;
        color.a = 0f;  // Start fully transparent
        presentationText.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / duration); // Fade in
            presentationText.color = color;
            yield return null;
        }

        color.a = 1f; // Ensure fully visible at the end
        presentationText.color = color;
    }

    // Fade the text out
    public IEnumerator FadeOutText(float duration)
    {
        float elapsed = 0f;
        Color color = presentationText.color;
        color.a = 1f;  // Start fully visible
        presentationText.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (elapsed / duration)); // Fade out
            presentationText.color = color;
            yield return null;
        }

        color.a = 0f; // Ensure fully transparent at the end
        presentationText.color = color;
    }
}