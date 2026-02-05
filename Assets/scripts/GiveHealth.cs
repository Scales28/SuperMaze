using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    public int healAmount = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
            Destroy(gameObject);  // Remove the item after pickup
        }
    }
}
