using UnityEngine;

public class BaseHealPickup : MonoBehaviour
{
    [Header("Heal Settings")]
    public float healAmount = 50f;      // How much health the base gets back

    // Called by SimpleCollectibleScript Type5
    public void Activate()
    {
        Base baseScript = GameObject.FindWithTag("Base")?.GetComponent<Base>();
        if (baseScript != null)
        {
            baseScript.Heal(healAmount);
            Debug.Log($"Base healed for {healAmount}");
        }
        else
            Debug.LogWarning("BaseHealPickup: No Base found!");
    }
}
