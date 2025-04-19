using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public GameObject tri;
    public GameObject BulletPrefab;
    public Camera cam;
    public Transform player;
    public float fireForce = 20f;
    public Transform firePoint;
    public int FiresShot = 0;
    public int FiresHit = 0;

    Vector2 mousePos;

    public void Attack()
    {
        FiresShot += 1;

        GunMovement gunMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<GunMovement>();

        Vector2 directionToMouse = ((Vector2)mousePos - (Vector2)firePoint.position).normalized;
        Vector2 spawnPos = (Vector2)firePoint.position + directionToMouse * 0.3f; // 0.3f is the offset distance

        GameObject bullet = Instantiate(BulletPrefab, spawnPos, firePoint.rotation);
        // Set the bullet's direction to the direction from the fire point to the mouse position
        // If we found the GunMovement script, assign it to the bullet
        if (gunMovement != null)
        {
            bullet.GetComponent<Bullet>().gunMovement = gunMovement;
        }

        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        tri.transform.position = player.position;
    }
    void FixedUpdate()
    {
        //Calculates the direction from the player's position to the mouse position.
        Vector2 lookDir = mousePos - (Vector2)tri.transform.position;
        //This calculates the angle
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        tri.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
