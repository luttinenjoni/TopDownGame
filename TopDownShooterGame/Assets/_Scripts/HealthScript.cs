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
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth; //Kohteella on synnyttyään täydet HP:t.
        UpdateHealthBar(); // HP-palkki täysille
    }

    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; //If the player receives more health than maxHealth, return currentHealth to MaxHealth.
            UpdateHealthBar();
        }
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
                audioManager.PlaySFX2(audioManager.enemyDieSFX);
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

    public int CurrentHealth()
        {
            return currentHealth;
        }
}
