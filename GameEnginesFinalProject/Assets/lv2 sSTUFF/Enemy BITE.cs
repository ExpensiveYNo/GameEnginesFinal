using UnityEngine;

public class EnemyBite : MonoBehaviour
{
    public Transform player;
    public float biteRange = 2f;
    public float biteCooldown = 1f;

    public GameObject deathScreen;

    float timer;
    bool dead = false;

    void Start()
    {
        if (deathScreen != null)
            deathScreen.SetActive(false);
    }

    void Update()
    {
        if (dead) return;

        timer += Time.deltaTime;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= biteRange && timer >= biteCooldown)
        {
            timer = 0f;
            Die();
        }
    }

    void Die()
    {
        dead = true;

        Time.timeScale = 0f;

        if (deathScreen != null)
            deathScreen.SetActive(true);
    }
}