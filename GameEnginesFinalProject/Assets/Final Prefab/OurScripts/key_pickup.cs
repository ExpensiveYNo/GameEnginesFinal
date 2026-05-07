using UnityEngine;
using UnityEngine.InputSystem;

public class key_pickup : MonoBehaviour
{
    public bool rotate; // do you want it to rotate?

    public float rotationSpeed;

    public AudioClip collectSound;

    //public GameObject collectEffect;

    public bool flag = false, is_open = false;

    // Use this for initialization
    void Start()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        flag = true;
    }

    void Update()
    {

        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        if (flag && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            is_open = true;
            //KeyHubScript.instance.AddPoint();
            Destroy(gameObject);
        }
    }

    //Doesn't work because object is not child of player object 
    //public void OnInteract(InputValue value)
    //{
    //    if (flag)
    //    {
    //        AudioSource.PlayClipAtPoint(collectSound, transform.position);
    //        is_open = true;
    //        //KeyHubScript.instance.AddPoint();

    //        Destroy(gameObject);
    //    }
    //}

}
