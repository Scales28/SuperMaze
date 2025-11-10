using UnityEngine;
using UnityEngine.SceneManagement; // Required to change scenes

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a specific tag (optional)
        if (other.CompareTag("Player")) // Replace "Player" with your tag
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
