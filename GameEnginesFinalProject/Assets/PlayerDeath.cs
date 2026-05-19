using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    GameObject deathScreen;
    bool dead = false;

    void Start()
    {
        // Find UI in scene (works with prefabs)
        deathScreen = GameObject.Find("DeathScreen");

        if (deathScreen != null)
            deathScreen.SetActive(false);
        else
            Debug.LogError("DeathScreen not found in scene. Must be named exactly 'DeathScreen'");
    }

    public void Die()
    {
        if (dead) return;

        dead = true;

        Time.timeScale = 0f;

        if (deathScreen != null)
            deathScreen.SetActive(true);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
}