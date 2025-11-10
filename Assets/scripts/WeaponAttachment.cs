using UnityEngine;

public class WeaponAttachment : MonoBehaviour
{
    public Transform weaponHolder; // The location where the weapon should attach
    public float rotationSpeed = 10f; // Speed of rotation around the player
    public float distanceFromPlayer = 1f; // The distance the weapon stays from the player
    private GameObject currentWeapon; // Store the weapon currently attached to the player
    private float currentAngle = 0f; // Store the current angle of the weapon

    private void Update()
    {
        if (currentWeapon != null)
        {
            RotateWeaponAndPlayer();
        }
    }

    // Attach the weapon to the player
    public void AttachWeapon(GameObject weapon)
    {
        if (weaponHolder == null)
        {
            Debug.LogError("Weapon holder is not assigned!");
            return;
        }

        if (currentWeapon != null)
        {
            Destroy(currentWeapon); // Destroy the previous weapon if there was one
        }

        currentWeapon = weapon; // Assign the new weapon
        currentWeapon.transform.position = weaponHolder.position; // Position the weapon at the holder
        currentWeapon.transform.SetParent(weaponHolder); // Parent the weapon to the holder
        currentWeapon.transform.localPosition = Vector3.zero; // Set local position relative to the holder

        currentWeapon.transform.rotation = Quaternion.identity; // Reset rotation to avoid inherited rotations
    }

    // Rotate the weapon around the player and rotate the player to match the sword
    private void RotateWeaponAndPlayer()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-axis is 0 to keep everything 2D

        // Calculate the direction from the weapon holder to the mouse position
        Vector3 direction = (mousePosition - weaponHolder.position).normalized;

        // Calculate the angle to rotate the weapon around the player
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Smoothly rotate towards the target angle (optional smooth rotation)
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);

        // Position the weapon at a fixed distance from the player and at the calculated angle
        Vector3 weaponPosition = weaponHolder.position + new Vector3(Mathf.Cos(currentAngle * Mathf.Deg2Rad) * distanceFromPlayer, Mathf.Sin(currentAngle * Mathf.Deg2Rad) * distanceFromPlayer, 0f);
        currentWeapon.transform.position = weaponPosition;

        // Rotate the weapon to match the direction it's facing
        currentWeapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

        // Rotate the player to match the weapon’s rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));
    }
}
