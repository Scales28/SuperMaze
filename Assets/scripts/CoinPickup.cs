using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinPickup : MonoBehaviour
{
    public int coinAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin picked up!");
            CurrencyManager.Instance.AddCoins(coinAmount);
            Destroy(gameObject);
        }
    }
}
