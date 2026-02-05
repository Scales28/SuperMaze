using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        Time.timeScale = 1f; // important if coming from pause
        SceneManager.LoadScene(sceneName);
    }
}
