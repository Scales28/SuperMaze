using UnityEngine;

public class TurnOffSprite : MonoBehaviour
{
    public GameObject spriteToTurnOff;
    private bool canTrigger = false;

    void Start()
    {
        spriteToTurnOff.SetActive(true);
        Invoke(nameof(EnableTrigger), 0.1f); // small delay
    }

    void EnableTrigger()
    {
        canTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canTrigger) return;

        if (other.CompareTag("Player"))
        {
            spriteToTurnOff.SetActive(false);
        }
    }
}
