using UnityEngine;
using UnityEngine.InputSystem;

public class WallInteract : MonoBehaviour
{
    public Transform player;
    public float range = 3f;

    public GameObject pressEText;

    void Start()
    {
        pressEText.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (Battery.ready && dist <= range)
        {
            pressEText.SetActive(true);

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            pressEText.SetActive(false);
        }
    }
}