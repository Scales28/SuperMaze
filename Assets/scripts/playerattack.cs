using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] public float meleeSpeed;

    [SerializeField] public float damage;

    float timeUntilMelee;

    private void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    // Detect when the sword (or attack) hits an enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Ensure the enemy has the "Enemy" tag
        {
            // Get the EnemyHealth component and apply damage
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage((int)damage); // Apply damage to the enemy
                Debug.Log("Enemy hit. Remaining Health: " + enemyHealth.GetCurrentHealth());
            }
        }
    }
}
