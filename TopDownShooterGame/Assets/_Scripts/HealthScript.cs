using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 10; //HP:n määrä
    public int currentHealth;
    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth; //Kohteella on synnyttyään täydet HP:t.
        UpdateHealthBar(); // HP-palkki täysille
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //HP:sta vähennetään damagen määrä
        UpdateHealthBar(); //Päivitä HP-palkki

        if (currentHealth <= 0)
        {
            Destroy(gameObject); //Tuhoaa kohteen, kun 0HP
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;//Päivitä HP-palkki
        }
    }
}
