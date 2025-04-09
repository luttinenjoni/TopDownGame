using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 5; // Amount of health to restore

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.GetComponent<HealthScript>()?.TakeDamage(-healthAmount); // Restore health by reducing damage                     
            Destroy(gameObject); // Destroy the health item after it's picked up           
        }
    }
}
