using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    private Vector2 movement; // Stores player input
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        rb.gravityScale = 0; // Disable gravity
    }

    void Update()
    {
        // Get input from the player
        movement.x = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        movement.y = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow keys
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }
}
