using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public int currentCoins = 0;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        Debug.Log("Coins: " + currentCoins);
    }

    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            Debug.Log("Spent coins. Remaining: " + currentCoins);
            return true;
        }

        Debug.Log("Not enough coins!");
        return false;
    }

    public int GetCoins()
    {
        return currentCoins;
    }
}
