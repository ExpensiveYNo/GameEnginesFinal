using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; // remove if you're using legacy Text

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance; // singleton so enemies can find it easily

    [Header("Win Condition")]
    public int enemiesToWin = 30;

    [Header("UI References")]
    public GameObject winPanel;       // drag your Win UI panel here
    public TMP_Text counterText;      // drag your counter Text here
    public GameObject alertTextPanel; // drag your alert Text panel here
    public float alertDisplayTime = 5f;

    private int enemiesDefeated = 0;

    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        alertTextPanel.SetActive(false);
        ShowPanel();
        winPanel.SetActive(false);
        UpdateUI();
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        UpdateUI();

        if (enemiesDefeated >= enemiesToWin)
        {
            TriggerWin();
        }
    }

    void UpdateUI()
    {
        counterText.text = $"Enemies: {enemiesDefeated} / {enemiesToWin}";
    }

    void TriggerWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // pause the game (optional)
    }

    public void ShowPanel()
    {
        StartCoroutine(HidePanelAfterDelay());
    }

    private IEnumerator HidePanelAfterDelay()
    {
        alertTextPanel.SetActive(true); // Show the panel
        yield return new WaitForSeconds(alertDisplayTime); // Wait
        alertTextPanel.SetActive(false); // Hide the panel
    }
}