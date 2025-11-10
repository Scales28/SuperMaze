using UnityEngine;

public class AIChase : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float chaseRange = 5f; // Range at which the enemy will start chasing the player
    public float moveSpeed = 3f; // Enemy movement speed
    public int damage = 10; // Amount of damage dealt when touching the player
    public float attackRange = 0.5f; // Range to trigger damage
    public float attackSpeed = 1f; // Time in seconds between attacks

    private float attackCooldown = 0f; // Timer for cooldown between attacks

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }

        // Reduce attack cooldown over time
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }

        // Attack only if in range and cooldown is done
        if (distanceToPlayer <= attackRange && attackCooldown <= 0f)
        {
            DealDamage();
            attackCooldown = attackSpeed; // Reset cooldown
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void DealDamage()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
