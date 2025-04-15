using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject EnemybulletPrefab;
    public Transform FirePoint;
    public float fireForce = 10f; // Bullet speed
    public float fireRate = 1f; // Time between shots
    private Transform player;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag
        InvokeRepeating(nameof(ShootAtPlayer), 1f, fireRate); // Repeat shooting
    }

    void ShootAtPlayer()
{
    if (player == null) return;
    //Haetaan pelaajan sijainti, jos pelaaja on olemassa.
    Vector2 direction = (player.position - FirePoint.position).normalized;
    //Create the bullet
    GameObject bullet = Instantiate(EnemybulletPrefab, FirePoint.position, Quaternion.identity);
    //Turn the bullet towards the player
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    // Set bullet velocity
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    audioManager.PlaySFX2(audioManager.enemyShootSFX);
        if (rb != null)
    {
        rb.linearVelocity = direction * fireForce;
    }
}
}
