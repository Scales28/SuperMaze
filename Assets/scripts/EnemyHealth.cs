using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    public int maxHealth = 100; // Set the maximum health in the Inspector
    private int currentHealth;

    private void Start()
    {
        // Initialize current health
        currentHealth = maxHealth;
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Subtract damage from current health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0

        // Output the current health in the console
        Debug.Log("Enemy took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // If health is 0 or less, call Die()
        }
    }

    // Function when enemy dies
    void Die()
    {
        Debug.Log("Enemy has died!"); // Print to the console when the enemy dies
        Destroy(gameObject); // Destroy the enemy object
    }

    // Add this method to return current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Optionally, you can expose a method to set the health from outside
    public void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        Debug.Log("Enemy health set to: " + currentHealth);
    }

    // Optionally, you can also expose a method to heal the enemy
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Enemy healed. Current health: " + currentHealth);
    }
}
