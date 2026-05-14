using UnityEngine;

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

            if (Input.GetKeyDown(KeyCode.E))
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