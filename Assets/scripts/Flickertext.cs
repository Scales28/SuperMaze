using System.Collections;
using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;

public class FlickerTextScript : MonoBehaviour
{
    [Header("Text Settings")]
    public TextMeshProUGUI flickerText;  // Reference to the TextMeshProUGUI component
    public string[] texts;  // Array of text strings to display
    public float timeBetweenTexts = 2f;  // Time to wait between each text
    public float timePerText = 2f;  // Time to display each text before changing
    public string nextSceneName;  // Scene to load after text display ends

    private void Start()
    {
        // Start the text flickering process when the scene starts
        StartCoroutine(FlickerThroughText());
    }

    // Coroutine to handle the text flickering
    IEnumerator FlickerThroughText()
    {
        // Loop through each piece of text
        foreach (string text in texts)
        {
            flickerText.text = text;  // Display the text
            yield return new WaitForSeconds(timePerText);  // Wait for the duration of the text
        }

        // Wait for a moment before changing scene
        yield return new WaitForSeconds(timeBetweenTexts);

        // Change to the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
