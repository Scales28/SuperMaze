using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Optional: add effects, damage, or sounds here
        Destroy(gameObject);
    }
}
