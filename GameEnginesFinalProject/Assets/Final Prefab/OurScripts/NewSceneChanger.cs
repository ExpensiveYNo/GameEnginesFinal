using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneChanger : MonoBehaviour
{
    public void LoadScene(string  sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
