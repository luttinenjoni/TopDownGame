using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXSource2;

    [Header("Audio Clip")]
    public AudioClip menubg;
    public AudioClip shootSFX;
    public AudioClip enemyShootSFX;
    public AudioClip footstepSFX;

    private void Start()
    {
        musicSource.clip = menubg;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlaySFX2(AudioClip clip)
    {
        SFXSource2.PlayOneShot(clip);
    }

}
