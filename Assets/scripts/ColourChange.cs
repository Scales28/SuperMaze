using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public Color touchedColor = Color.yellow;
    private Color originalColor;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.color = touchedColor;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        sprite.color = touchedColor;
    }
}

}
