using UnityEngine;


public class OrbScript : MonoBehaviour
{

    public SpawnManager spawnManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spawnManager.OrbTaken();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
