using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GunMovement gunMovement;


    void Start()
    {
        // Find the child object called "Triangle" and get the WeaponScript attached to it
        Transform triangleTransform = GameObject.FindGameObjectWithTag("Player").transform.Find("Triangle");

        if (triangleTransform != null)
        {
            gunMovement = triangleTransform.GetComponent<GunMovement>();
        }
        else
        {
            Debug.LogError("Triangle object not found as a child of Player.");
        }
    }


    void OnBecameInvisible() {
        Destroy(gameObject);
    } //Luoti tuhoutuu off-screenissa
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();

        if (healthScript != null) //Jos luodin kohteella on HP-skripti...
        {
            gunMovement.FiresHit += 1; //...Luoti merkataan osumaksi weapon -skriptiin.
            healthScript.TakeDamage(1); //...kohde menettää 1 HP.
        }

        Destroy(gameObject);
    }
}
