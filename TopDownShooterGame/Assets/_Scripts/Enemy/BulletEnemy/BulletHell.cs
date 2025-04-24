using UnityEngine;
using System.Collections.Generic;

public class BulletHell : MonoBehaviour
{
    public GameObject EnemybulletPrefab;
    public List<FirePointData> FirePoints; // List of fire points
    public float fireForce = 15f; // Bullet speed
    public float fireRate = 0.4f; // Time between shots

    AudioManager audioManager;

    [System.Serializable]
    public class FirePointData
    {
        public Transform firePoint;
        public Direction direction;
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 1f, fireRate); // Repeat shooting

    }

    void Shoot()
    {
        foreach (var firePointData in FirePoints)
        {
            //Create the bullet
            GameObject bullet = Instantiate(EnemybulletPrefab, firePointData.firePoint.position, Quaternion.identity);

            // Set bullet direction based on the enum
            Vector2 direction = GetDirectionVector(firePointData.direction);

            // Turn the bullet towards the direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            audioManager.PlaySFX2(audioManager.enemyShootSFX);

            // Set bullet velocity
            if (rb != null)
            {
                rb.linearVelocity = direction * fireForce;
            }
        }
    }

    Vector2 GetDirectionVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }
}
