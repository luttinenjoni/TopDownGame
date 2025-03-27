using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
