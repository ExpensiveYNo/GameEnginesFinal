using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHits = 3;
    int currentHits = 0;

void Start()
{
    deathScreen.SetActive(false);
}

    public GameObject deathScreen;

    public void TakeHit()
    {
        currentHits++;

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}