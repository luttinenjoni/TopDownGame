using UnityEngine;


public class OrbScript : MonoBehaviour
{
    public float timer = 0f; //Create a timer that will start when the player takes the orb.
    public bool isRunning = false;

    public SpawnManager spawnManager;
    public ScoreManager scoreManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        scoreManager.StartTimer();

        spawnManager.OrbTaken();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
