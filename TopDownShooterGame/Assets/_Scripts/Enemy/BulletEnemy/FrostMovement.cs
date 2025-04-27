using UnityEngine;

public class FrostMovement : MonoBehaviour
{
    public float speed = 3f; // Movement speed

    private Transform player;
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    public float stopDistance = 0.05f; //How close the enemy can get without stopping
    public float avoidanceStrength = 0.1f; //How sharply the enemy turns
    public float rayLength = 0.2f; //How far the enemy can detect the obstacles
    public Animator animator;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";


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

        animator.SetFloat(horizontal, movementDirection.x);
        animator.SetFloat(vertical, movementDirection.y);
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < stopDistance)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Raycast forward to detect obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength);
        if (hit.collider != null && hit.collider.gameObject != player.gameObject)
        {
            // Obstacle avoidance: steer to the right or left
            Vector2 perp = Vector2.Perpendicular(direction).normalized;
            Vector2 avoidanceDir = direction + perp * avoidanceStrength;
            rb.linearVelocity = avoidanceDir.normalized * speed;
        }
        else
        {
            // No obstacle, move directly toward player
            rb.linearVelocity = rb.position + speed * Time.fixedDeltaTime * movementDirection;
        }
    }
}
