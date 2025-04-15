using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator ani;
    public GunMovement weapon;

    public float moveSpeed = 5f;
    public Camera cam;

    Vector2 movement;
    AudioManager audioManager;

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
