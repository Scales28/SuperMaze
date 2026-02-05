using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class ChangeSceneOnTouch2D : MonoBehaviour
{
    public string targetSceneName = "YourSceneName"; // The scene name to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the object that collided has the Player tag
        {
            // Load the scene
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
