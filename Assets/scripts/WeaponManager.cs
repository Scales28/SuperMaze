using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    // Variable to store the selected weapon (you can store the weapon index, name, or ID)
    public string selectedWeapon = "Sword"; // Default weapon

    private void Awake()
    {
        // Singleton pattern to ensure there's only one instance of WeaponManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the WeaponManager across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        // Load weapon selection from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("SelectedWeapon"))
        {
            selectedWeapon = PlayerPrefs.GetString("SelectedWeapon");
        }
    }

    // Call this method to change the weapon
    public void SetWeapon(string weaponName)
    {
        selectedWeapon = weaponName;
        PlayerPrefs.SetString("SelectedWeapon", weaponName); // Save the selected weapon to PlayerPrefs
        PlayerPrefs.Save(); // Ensure the data is saved immediately
    }

    // Call this method to get the current selected weapon
    public string GetWeapon()
    {
        return selectedWeapon;
    }
}
