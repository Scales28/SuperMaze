using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public Slider healthBar;

    [Header("Scene Settings")]
    public string sceneToLoadOnDeath; // Set this in the Inspector

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player took damage. Current health: " + currentHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
        else
        {
            Debug.LogWarning("Health bar slider not assigned.");
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        if (!string.IsNullOrEmpty(sceneToLoadOnDeath))
        {
            SceneManager.LoadScene(sceneToLoadOnDeath);
        }
        else
        {
            Debug.LogWarning("No scene name set to load on death.");
        }
    }

    public void Heal(int amount)
{
    currentHealth += amount;
    if (currentHealth > maxHealth)
        currentHealth = maxHealth;

    Debug.Log("Player healed. Current health: " + currentHealth);
}

}
