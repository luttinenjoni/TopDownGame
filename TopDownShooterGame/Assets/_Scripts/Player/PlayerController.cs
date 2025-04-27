using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator ani;
    public GunMovement weapon;
    public Camera cam;
    AudioManager audioManager;

    Vector2 movement;

    public float moveSpeed = 5f;
    public float footstepInterval = 0.2f;
    private float footstepTimer = 0f;
    public float fireRate = 0.5f; // Time between shots in seconds
    private float nextFireTime = 0f;
    public bool alive = true; // Player's alive status


    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (!alive) // If the player is not alive, do not process input
            return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        ani.SetFloat(horizontal, movement.x);
        ani.SetFloat(vertical, movement.y);

        if (movement != Vector2.zero)
        {
            footstepTimer += Time.deltaTime;
            if (footstepTimer >= footstepInterval)
            {
                footstepTimer = 0f;
                audioManager.PlaySFX2(audioManager.footstepSFX);
            }
        }
        else
        {
            footstepTimer = 0f; // Reset timer if not moving
        }

        if (Input.GetMouseButton(0))
        {
            if (Time.timeScale == 0f) // If the game is paused, don't shoot
                return;

            // Check if enough time has passed since the last shot
            if (Time.time >= nextFireTime)
            {
                audioManager.PlaySFX(audioManager.shootSFX);
                weapon.Attack();
                nextFireTime = Time.time + fireRate;
            }
        }

}

    public void FireRateUpgrade(float fire)
    {
        fireRate = Mathf.Max(0.05f, fireRate - fire); // don't let fireRate go below 0.05
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

}
