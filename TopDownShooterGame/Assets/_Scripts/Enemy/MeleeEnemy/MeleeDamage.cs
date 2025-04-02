using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public float damageInterval = 1f; // Time interval between damage applications
    private float lastDamageTime = 0f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if enough time has passed since the last damage application
            if (Time.time - lastDamageTime >= damageInterval)
            {
                // Try to get the HealthScript component and apply damage
                HealthScript playerHealth = collision.gameObject.GetComponent<HealthScript>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1);
                    lastDamageTime = Time.time; // Update the last damage time
                }
            }
        }
    }
}
