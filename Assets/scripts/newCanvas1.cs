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
    public AudioSource audioSource;
    public AudioClip soundToPlay;
    public int playSoundAtIndex = -1;

    private Coroutine textCoroutine;
    private bool hasSkipped = false;

    private void Start()
    {
        textCanvas.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        mainCanvas.SetActive(false);
        textCanvas.SetActive(true);

        textCoroutine = StartCoroutine(FlickerThroughText());
    }

    public void OnSkipButtonClicked()
    {
        if (hasSkipped) return;
        hasSkipped = true;

        if (textCoroutine != null)
            StopCoroutine(textCoroutine);

        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FlickerThroughText()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            flickerText.text = texts[i];

            if (i == playSoundAtIndex && soundToPlay != null && audioSource != null)
            {
                audioSource.PlayOneShot(soundToPlay);
            }

            float duration = (i < textDurations.Length) ? textDurations[i] : 2f;
            yield return new WaitForSeconds(duration);
        }

        yield return new WaitForSeconds(timeAfterAllTexts);

        if (!hasSkipped)
            SceneManager.LoadScene(nextSceneName);
    }
}
