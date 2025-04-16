using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXSource2;
    [SerializeField] AudioSource SFXSource3;

    [Header("Audio Clip")]
    public AudioClip menubg;
    public AudioClip shootSFX;
    public AudioClip enemyShootSFX;
    public AudioClip footstepSFX;
    public AudioClip playClickSFX;
    public AudioClip clickSFX;
    public AudioClip healthSFX;
    public AudioClip enemyDieSFX;

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
    public void PlaySFX3(AudioClip clip)
    {
        SFXSource3.PlayOneShot(clip);
    }

}
