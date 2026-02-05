using UnityEngine;

public class SceneFreezeUI : MonoBehaviour
{
    public GameObject currentCanvas; // The current canvas to hide
    public GameObject newCanvas;     // The new canvas to show

    void Start()
    {
        Time.timeScale = 0f; // Freeze the game
        currentCanvas.SetActive(true); // Show the current canvas
        newCanvas.SetActive(false);    // Hide the new canvas initially
    }

    // Hook this to a UI Button's OnClick
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Unfreeze the game
        currentCanvas.SetActive(false); // Hide the current canvas
        newCanvas.SetActive(true); // Show the new canvas
    }
}
