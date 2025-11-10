using UnityEngine;

public class EnemyHealthBoss : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    public int maxHealth = 100; // Maximum enemy health
    private int currentHealth;

    [Header("Death Sprite Settings")]
    public GameObject deathSprite; // Assign a sprite or GameObject in the Inspector
    public bool disableEnemyOnDeath = true; // Optional toggle to hide enemy

    private void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Make sure death sprite starts off
        if (deathSprite != null)
            deathSprite.SetActive(false);
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Enemy took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function when enemy dies
    void Die()
    {
        Debug.Log("Enemy has died!");

        // Turn on the death sprite if one is assigned
        if (deathSprite != null)
        {
            deathSprite.SetActive(true);
        }

        // Optionally disable the enemy instead of destroying it
        if (disableEnemyOnDeath)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            // You can disable scripts like movement here too
        }
    }

    // Get current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Set health manually
    public void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Enemy health set to: " + currentHealth);
    }

    // Heal the enemy
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Enemy healed. Current health: " + currentHealth);
    }
}
