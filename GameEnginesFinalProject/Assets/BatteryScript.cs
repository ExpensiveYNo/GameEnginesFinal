using UnityEngine;

public class Battery : MonoBehaviour
{
    public static int count = 0;
    public static bool ready = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count++;
Debug.Log(count);
            if (count >=50)
                ready = true;

            Destroy(gameObject);
        }
    }
}