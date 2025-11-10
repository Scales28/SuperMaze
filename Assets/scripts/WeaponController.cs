using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float rotationSpeed = 10f;  // Speed of the weapon's rotation around the player
    public int damageAmount = 10;       // Damage the weapon deals to enemies

    private void Update()
    {
        RotateWeapon();
        if (Input.GetMouseButtonDown(0)) // Left click to deal damage
        {
            DealDamage();
        }
    }

    // This function rotates the weapon around the player's body using the mouse position
    private void RotateWeapon()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Get mouse position in world space
        mousePos.z = 0; // Keep the weapon on the same plane (2D)

        Vector3 direction = mousePos - transform.position;  // Direction from weapon to mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // Angle in degrees
        transform.rotation = Quaternion.Euler(0, 0, angle);  // Apply the rotation to the weapon
    }

    // This function deals damage to any enemy the weapon is touching
    private void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1f);  // Check for enemies in radius

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))  // Ensure it's an enemy
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);  // Apply damage
                Debug.Log("Dealt " + damageAmount + " damage to " + enemy.name);
            }
        }
    }

    // Initialize weapon (called when weapon is attached to player)
    public void InitializeWeapon()
    {
        // Optional initialization for weapon properties
    }
}
