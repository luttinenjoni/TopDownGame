using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy bullet after lifetime.
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        //Bullet takes 1HP from Player and gets destroyed after it.
        other.GetComponent<HealthScript>()?.TakeDamage(1);
        Destroy(gameObject);
    }
    if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject) ;
        }
    }

    }
