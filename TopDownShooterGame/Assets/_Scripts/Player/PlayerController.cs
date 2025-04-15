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



    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale == 0f) //Jos peli on pausella, älä ammu.
                return;
            audioManager.PlaySFX(audioManager.shootSFX);
            weapon.Attack();
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }

}
