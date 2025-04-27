using UnityEngine;

public class BulletUpgrade : MonoBehaviour
{
    public float newFireRate = 0.4f; // Amount of health to restore
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            audioManager.PlaySFX3(audioManager.healthSFX);
            c.GetComponent<PlayerMovement>()?.FireRateUpgrade(newFireRate); // Restore health by reducing damage                     
            Destroy(gameObject); // Destroy the health item after it's picked up           
        }
    }
}
