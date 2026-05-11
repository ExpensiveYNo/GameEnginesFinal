using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour
{
    public enum CollectibleTypes { NoType, Type1, Type2, Type3, Type4, Type5 };
    public CollectibleTypes CollectibleType;
    public bool rotate;
    public float rotationSpeed;
    public AudioClip collectSound;
    public GameObject collectEffect;

    [Header("Ammo Pack Settings (Type3)")]
    //public int ammoRefillAmount = -1; // -1 = full refill, any positive number = partial refill

    public bool flag = false;

    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Collect();
    }

    public void Collect()
    {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

        if (CollectibleType == CollectibleTypes.NoType)
        {
            Debug.Log("Do NoType Command");
        }
        else if (CollectibleType == CollectibleTypes.Type1)
        {
            //CoinScore.instance.AddPoint();
        }
        else if (CollectibleType == CollectibleTypes.Type2)
        {
            //KeyHubScript.instance.AddPoint();
        }
        else if (CollectibleType == CollectibleTypes.Type3)
        {
            // Refills ammo — full refill by default, or set ammoRefillAmount in Inspector for a partial pack
            //if (RaycastShooter.instance != null)
            //    RaycastShooter.instance.RefillAmmo(ammoRefillAmount);
            //else
            //    Debug.LogWarning("SimpleCollectibleScript: No RaycastShooter instance found in scene!");
        }
        else if (CollectibleType == CollectibleTypes.Type4)
        {
            FireRatePickup fireRate = GetComponent<FireRatePickup>();
            if (fireRate != null)
                fireRate.Activate();
            else
                Debug.LogWarning("Type4 collectible is missing FireRatePickup component!");
        }
        else if (CollectibleType == CollectibleTypes.Type5)
        {
            BaseHealPickup heal = GetComponent<BaseHealPickup>();
            if (heal != null)
                heal.Activate();
            else
                Debug.LogWarning("Type5 collectible is missing BaseHealPickup component!");
        }

        Destroy(gameObject);
    }
}