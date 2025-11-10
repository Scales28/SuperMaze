using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeFighter : MonoBehaviour
{
    [Header("Targeting")]
    public Transform player; // Can be set manually or found on Start
    public LayerMask obstacleMask; // Set this to include walls/obstacles

    [Header("Movement")]
    public float speed = 2f;
    public float stopDistance = 2f; // The distance at which the AI will stop to attack

    [Header("Vision")]
    public float visionRange = 10f; // How far the AI can see
    public float attackRange = 1.5f; // The range at which the AI will attack the player

    [Header("Attack")]
    public float attackCooldown = 1f; // Time between attacks
    private float lastAttackTime;
    public int attackDamage = 10; // Damage dealt during attack

    void Start()
    {
        // Optional: automatically find player if not set in Inspector
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
                player = foundPlayer.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        // Direction to the player
        Vector2 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Raycast to check if there's a clear line of sight to the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRange, ~obstacleMask);

        if (hit.collider != null)
        {
            if (hit.collider.transform == player)
            {
                // Debugging to see if the player is within line of sight
                Debug.Log("Player in sight!");

                // Distance from the AI to the player
                float distance = Vector2.Distance(transform.position, player.position);

                // If the player is too far, continue chasing
                if (distance > attackRange)
                {
                    // Move towards the player
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }
                else
                {
                    // Stop and attack if within attack range
                    if (Time.time > lastAttackTime + attackCooldown)
                    {
                        Attack();
                        lastAttackTime = Time.time; // Reset the attack cooldown timer
                    }
                }
            }
        }
        else
        {
            // Debugging to see if the AI lost sight of the player
            Debug.Log("Player not in sight!");
        }

        // Debugging line to visualize the AI's vision range
        Debug.DrawRay(transform.position, direction * visionRange, Color.red);
    }

    void Attack()
    {
        // Add the attack logic here (e.g., deal damage to the player)
        Debug.Log("Attacking the player!");

        // Example: Player health deduction could go here
        if (player != null)
        {
            // Assuming the player has a health script that takes damage
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}
