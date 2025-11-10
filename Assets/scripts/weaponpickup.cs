using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private bool isPickedUp = false; // Track if the weapon is picked up

    void Update()
    {
        // When the player clicks on the weapon and it's not already picked up
        if (Input.GetMouseButtonDown(0) && !isPickedUp)
        {
            TryPickUpWeapon();
        }
    }

    private void TryPickUpWeapon()
    {
        // Perform a raycast from the mouse position to detect if the player clicked on the weapon
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Weapon"))
        {
            WeaponAttachment weaponAttachment = hit.collider.GetComponentInParent<WeaponAttachment>(); // Attach from the player's WeaponAttachment script

            if (weaponAttachment != null)
            {
                weaponAttachment.AttachWeapon(hit.collider.gameObject); // Attach the weapon to the player
                isPickedUp = true; // Mark the weapon as picked up
            }
        }
    }
}
