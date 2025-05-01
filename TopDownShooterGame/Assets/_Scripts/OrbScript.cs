using UnityEngine;


public class OrbScript : MonoBehaviour
{
    public float timer = 0f; //Create a timer that will start when the player takes the orb.
    public bool isRunning = false;

    public SpawnManager spawnManager;
    private ScoreManager scoreManager;
    public PlayerMovement playerMovement; // Reference to the Player script

    void Start()
    {
        scoreManager = ScoreManager.Instance; //Get the ScoreManager instance
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerMovement.obtained = true;
        scoreManager.StartTimer();

        spawnManager.OrbTaken();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
