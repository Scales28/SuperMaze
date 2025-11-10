using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject spriteToEnable; // The sprite you want to turn on

    private void Start()
    {
        if (spriteToEnable != null)
            spriteToEnable.SetActive(false); // Make sure it starts off
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object we collided with has a specific tag
        if (other.CompareTag("Player"))
        {
            if (spriteToEnable != null)
                spriteToEnable.SetActive(true); // Turn on the sprite
        }
    }
}
