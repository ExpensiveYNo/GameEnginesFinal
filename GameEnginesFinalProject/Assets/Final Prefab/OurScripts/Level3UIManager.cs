using UnityEngine;

public class Level3UIManager : MonoBehaviour
{
    [SerializeField] GameObject lossPanel; 

    void Start()
    {
        // Make sure both panels start hidden
        if (lossPanel != null) lossPanel.SetActive(false);
    }

    public void ShowLossPanel()
    {
        if (lossPanel != null) lossPanel.SetActive(true);
    }

    // Wire these to your buttons in the Inspector
    public void OnRestartPressed()
    {
        Time.timeScale = 1f;
        Level3LevelManager.instance.Restart();
    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1f;
        Level3LevelManager.instance.GoToMainMenu();
    }
}