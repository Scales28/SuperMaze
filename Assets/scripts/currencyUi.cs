using UnityEngine;
using TMPro;

public class currencyUi : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateCoinUI(); // Show current amount on start
    }

    private void Update()
    {
        // Optionally keep it always updated every frame
        UpdateCoinUI();
    }

    public void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + CurrencyManager.Instance.GetCoins().ToString();
        }
    }
}
