using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3LevelManager : MonoBehaviour
{
    public static Level3LevelManager instance;

    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void GameOver()
    {
        isGameOver = true;
        //Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Level3UIManager _ui = GetComponent<Level3UIManager>();
        if (_ui != null)
            _ui.ShowLossPanel();
    }

    public void Restart()
    {
        Debug.Log("Restart pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
