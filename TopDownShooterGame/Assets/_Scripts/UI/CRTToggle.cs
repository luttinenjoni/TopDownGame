using UnityEngine;
using UnityEngine.UI;

public class CRTToggle : MonoBehaviour
{
    public Material crtMaterial;      // The material with CRT effect
    public Material defaultMaterial;  // The default material without CRT effect
    public Renderer targetRenderer;    // The renderer to apply the material to
    public Toggle crtToggle;          // UI Toggle to control the CRT effect

    void Start()
    {
        // Initialize the toggle state
        crtToggle.onValueChanged.AddListener(OnCRTToggleChanged);

        // Set the initial material based on the toggle's state
        SetMaterial(crtToggle.isOn);
    }

    void OnCRTToggleChanged(bool isOn)
    {
        // Toggle the material based on the toggle state
        SetMaterial(isOn);
    }

    void SetMaterial(bool isCRT)
    {
        // Switch between the default material and the CRT material
        if (isCRT)
        {
            targetRenderer.material = crtMaterial;  // Apply CRT material
        }
        else
        {
            targetRenderer.material = defaultMaterial;  // Apply default material
        }
    }
}
