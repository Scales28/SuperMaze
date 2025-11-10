using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class newCanvas1 : MonoBehaviour
{
    [Header("Canvas Settings")]
    public GameObject mainCanvas;
    public GameObject textCanvas;

    [Header("Text Settings")]
    public TextMeshProUGUI flickerText;
    public string[] texts;
    public float[] textDurations;
    public float timeAfterAllTexts = 2f;
    public string nextSceneName;

    [Header("Audio Settings")]
    public AudioSource audioSource;         // Reference to the AudioSource component
    public AudioClip soundToPlay;           // The sound you want to play
    public int playSoundAtIndex = -1;       // Index at which to play the sound (-1 = don't play)

    private void Start()
    {
        textCanvas.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        mainCanvas.SetActive(false);
        textCanvas.SetActive(true);

        StartCoroutine(FlickerThroughText());
    }

    IEnumerator FlickerThroughText()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            flickerText.text = texts[i];

            // Play sound if we're at the specified index
            if (i == playSoundAtIndex && soundToPlay != null && audioSource != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }

            float duration = (i < textDurations.Length) ? textDurations[i] : 2f;
            yield return new WaitForSeconds(duration);
        }

        yield return new WaitForSeconds(timeAfterAllTexts);
        SceneManager.LoadScene(nextSceneName);
    }
}
