using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip menubg;

    private void Start()
    {
        musicSource.clip = menubg;
        musicSource.Play();
    }

}
