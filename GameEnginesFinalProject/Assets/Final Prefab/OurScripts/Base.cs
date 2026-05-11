using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Base : MonoBehaviour
{
    [Header("Base Settings")]
    public float maxHealth = 500f;

    [Header("UI")]
    public TMP_Text baseHealthText;             // Optional UI text to show base health

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        UpdateUI();
        Debug.Log($"Base took {amount} damage. HP: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0f)
            BaseDestroyed();
    }

    void UpdateUI()
    {
        if (baseHealthText != null)
            baseHealthText.text = $"Base HP: {currentHealth}/{maxHealth}";
    }

    void BaseDestroyed()
    {
        Debug.Log("Base destroyed! Game over.");
        LevelManager.instance.GameOver();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateUI();
        Debug.Log($"Base healed {amount} HP. HP: {currentHealth}/{maxHealth}");
    }
}
