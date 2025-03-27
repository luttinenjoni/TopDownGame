using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnBecameInvisible() {
        Destroy(gameObject);
    } //Luoti tuhoutuu off-screenissa
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();

        if (healthScript != null) //Jos luodin kohteella on HP-skripti...
        {
            healthScript.TakeDamage(1); //...kohde menettää 1 HP.
        }

        Destroy(gameObject);
    }
}
