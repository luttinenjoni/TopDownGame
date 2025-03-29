using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Movement speed
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Find player by tag
    }

    void Update()
    {
        if (player == null) return;

        if (gameObject.name.StartsWith("PinkSquare")) //Jos vihollinen on pinkki neliö, se liikkuu pelaajaa kohti.
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        
    }
}
