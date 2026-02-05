using UnityEngine;
using UnityEngine.UI;

public class ClickCooldown : MonoBehaviour
{
    public float cooldownTime = 2f;
    public Slider cooldownSlider;

    private float timer;
    private bool isCoolingDown;

    void Start()
    {
        cooldownSlider.gameObject.SetActive(false);
        cooldownSlider.value = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCoolingDown)
        {
            StartCooldown();
        }

        if (!isCoolingDown) return;

        timer -= Time.deltaTime;
        cooldownSlider.value = timer / cooldownTime;

        if (timer <= 0f)
        {
            EndCooldown();
        }
    }

    void StartCooldown()
    {
        isCoolingDown = true;
        timer = cooldownTime;

        cooldownSlider.gameObject.SetActive(true);
        cooldownSlider.value = 1f;
    }

    void EndCooldown()
    {
        isCoolingDown = false;
        cooldownSlider.value = 0f;
        cooldownSlider.gameObject.SetActive(false);
    }

    public bool CanClick()
    {
        return !isCoolingDown;
    }
}
