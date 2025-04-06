using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Movement speed

    private Transform player;
    private Vector2 movementDirection;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        // Calculate direction toward the player
        movementDirection = (player.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Apply movement using Rigidbody2D
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movementDirection);
    }
}

