using UnityEngine;
using System.Collections;

public class FireRatePickup : MonoBehaviour
{
    [Header("Fire Rate Boost Settings")]
    public float boostMultiplier = 2f;      // How much faster the fire rate gets (2 = twice as fast)
    public float boostDuration = 10f;       // How long the boost lasts in seconds

    // Called by SimpleCollectibleScript Type4
    public void Activate()
    {
        RaycastShooter shooter = RaycastShooter.instance;
        if (shooter != null)
            shooter.StartCoroutine(ApplyBoost(shooter));
        else
            Debug.LogWarning("FireRatePickup: No RaycastShooter instance found!");
    }

    IEnumerator ApplyBoost(RaycastShooter shooter)
    {
        float originalFireRate = shooter.fireRate;
        shooter.fireRate /= boostMultiplier;    // Lower fireRate = faster shooting

        Debug.Log($"Fire rate boosted for {boostDuration}s");
        yield return new WaitForSeconds(boostDuration);

        shooter.fireRate = originalFireRate;    // Restore original
        Debug.Log("Fire rate boost ended");
    }
}