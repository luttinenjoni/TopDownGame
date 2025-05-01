using UnityEngine;
using UnityEngine.UI;

public class HealthScriptBossLevel : MonoBehaviour
{
    public int maxHealth = 10; //HP:n m‰‰r‰
    public int currentHealth;
    public Slider healthBar;
    private Transform player;
    public GameOverManager gameOverManager;
    public GameObject healthItemPrefab;
    public GameObject BulletItemPrefab;
    public BulletHell bulletHell;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth; //Kohteella on synnytty‰‰n t‰ydet HP:t.
        UpdateHealthBar(); // HP-palkki t‰ysille
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
        currentHealth -= damage; //HP:sta v‰hennet‰‰n damagen m‰‰r‰
        UpdateHealthBar(); //P‰ivit‰ HP-palkki

        // Fire rate increase for boss based on health
        if (CompareTag("Boss") && bulletHell != null)
        {
            bulletHell.CheckHealthAndUpdateFireRate(currentHealth);
        }

        if (currentHealth <= 0)
        {

            if (gameObject.CompareTag("Player"))
            {
                player.GetComponent<PlayerMovement>().alive = false; //Pelaaja kuolee
                PlayerDies();
            }

            if (CompareTag("Enemy") || CompareTag("Boss"))
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddScore(100);
                    ScoreManager.Instance.EnemyKilled();
                }

                Vector3 spawnPos = transform.position;

                if (Random.value < 0.35f && healthItemPrefab != null)
                {
                    Instantiate(healthItemPrefab, spawnPos, Quaternion.identity);
                }

                if (Random.value < 0.75f && BulletItemPrefab != null)
                {
                    Vector3 bulletOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-2f, 2f), 0f);
                    Instantiate(BulletItemPrefab, spawnPos + bulletOffset, Quaternion.identity);
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
            healthBar.value = (float)currentHealth / maxHealth;//P‰ivit‰ HP-palkki
        }
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }
}
