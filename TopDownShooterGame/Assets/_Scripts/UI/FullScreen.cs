using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    public void ToggleFullScreen()
    {
        if (Screen.fullScreen)
        {
            // Switch to windowed
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.fullScreen = false;
            Debug.Log("Switched to Windowed");
        }
        else
        {
            // Switch to fullscreen
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Screen.fullScreen = true;
            Debug.Log("Switched to Fullscreen");
        }
    }
}
