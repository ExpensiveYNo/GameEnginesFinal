using UnityEngine;
using UnityEngine.UI;
using TMPro; // remove if you're using legacy Text

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance; // singleton so enemies can find it easily

    [Header("Win Condition")]
    public int enemiesToWin = 30;

    [Header("UI References")]
    public GameObject winPanel;       // drag your Win UI panel here
    public TMP_Text counterText;      // drag your counter Text here

    private int enemiesDefeated = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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
}