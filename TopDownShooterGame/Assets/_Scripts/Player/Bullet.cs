using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    private Collider2D playerCollider;
    private Collider2D bulletCollider;

    void Start()
    {

        playerCollider = player.GetComponent<BoxCollider2D>();
        bulletCollider = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(playerCollider, bulletCollider);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
