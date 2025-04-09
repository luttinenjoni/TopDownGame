using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 10; //HP:n määrä
    public int currentHealth;
    public Slider healthBar;
    private Transform player;
    public GameOverManager gameOverManager;
    public GameObject healthItemPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth; //Kohteella on synnyttyään täydet HP:t.
        UpdateHealthBar(); // HP-palkki täysille
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //HP:sta vähennetään damagen määrä
        UpdateHealthBar(); //Päivitä HP-palkki

        if (currentHealth <= 0)
        {

            if (gameObject.CompareTag("Player"))
            {
                PlayerDies();
            }

            if (gameObject.CompareTag("Enemy"))
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddScore(100);
                }
                ScoreManager.Instance.EnemyKilled();

                if (Random.value < 0.15f && healthItemPrefab != null)
                {
                    Instantiate(healthItemPrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);

            }
            
        }
    }

    void PlayerDies()
    {
        StartCoroutine(gameOverManager.ShowGameOver());
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;//Päivitä HP-palkki
        }
    }
}
