using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeCost = 50;

    public enum UpgradeType
    {
        MaxHealth,
        Damage,
        MeleeCooldown,
        MoveSpeed
    }

    public UpgradeType upgradeType;
    public float upgradeAmount = 10f;

    [Header("References")]
    public PlayerHealth playerHealth;
    public playerattack playerAttack;
    public Movement playerMovement;

    public void ApplyUpgrade()
    {
        if (!CurrencyManager.Instance.SpendCoins(upgradeCost))
        {
            Debug.Log("Not enough coins to upgrade.");
            return;
        }

        switch (upgradeType)
        {
            case UpgradeType.MaxHealth:
                playerHealth.maxHealth += Mathf.RoundToInt(upgradeAmount);
                playerHealth.TakeDamage(0); // Updates UI and clamps health
                Debug.Log($"Upgraded Max Health to {playerHealth.maxHealth}");
                break;

            case UpgradeType.Damage:
                playerAttack.damage += upgradeAmount;
                Debug.Log($"Upgraded Damage to {playerAttack.damage}");
                break;

            case UpgradeType.MeleeCooldown:
                playerAttack.meleeSpeed = Mathf.Max(0.1f, playerAttack.meleeSpeed - upgradeAmount);
                Debug.Log($"Upgraded Melee Speed (cooldown) to {playerAttack.meleeSpeed}");
                break;

            case UpgradeType.MoveSpeed:
                playerMovement.moveSpeed += upgradeAmount;
                Debug.Log($"Upgraded Move Speed to {playerMovement.moveSpeed}");
                break;
        }
    }
}
