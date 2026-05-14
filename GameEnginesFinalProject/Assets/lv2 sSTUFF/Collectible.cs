using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public TMP_Text collected;
    static int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count++;
            collected.text = count.ToString();
            Destroy(gameObject);
        }
    }
}