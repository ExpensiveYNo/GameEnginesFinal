using UnityEngine;

public class EnemyBite : MonoBehaviour
{
    public Transform player;
    public float biteRange = 2f;
    public float biteCooldown = 1f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= biteRange && timer >= biteCooldown)
        {
            timer = 0f;

            player.GetComponent<PlayerHealth>().TakeHit();
        }
    }
}