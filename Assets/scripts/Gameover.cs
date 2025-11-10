using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            // Destroy the block that misses the stack
            Destroy(collision.gameObject);

            // End the game
            Debug.Log("Game Over!");
            Time.timeScale = 0; // Pause the game
        }
    }
}
