using UnityEngine;

public class LootDrop : MonoBehaviour
{
    [System.Serializable]
    public class LootEntry
    {
        public GameObject prefab;
        [Range(0f, 1f)] public float chance;
    }

    [Header("Loot Table")]
    public LootEntry[] lootTable;

    [Header("Spawn Settings")]
    public float dropHeightOffset = 0.5f;
    public Transform customSpawnPoint;      // Drag your LootSpawnSpot object here

    // Hook this up to the Health onDeath UnityEvent in the Inspector
    public void Drop()
    {
        // Shuffle the loot table so there's no bias toward entries at the top
        LootEntry[] shuffled = (LootEntry[])lootTable.Clone();
        for (int i = shuffled.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            LootEntry temp = shuffled[i];
            shuffled[i] = shuffled[j];
            shuffled[j] = temp;
        }

        // Only drop the first entry that passes its chance roll — one drop max
        foreach (LootEntry entry in shuffled)
        {
            if (entry.prefab == null) continue;

            if (Random.value <= entry.chance)
            {
                SpawnLoot(entry.prefab);
                return; // Stop after first successful drop
            }
        }
    }

    void SpawnLoot(GameObject prefab)
    {
        Vector3 spawnPos;

        GameObject lootSpawnSpot = GameObject.FindWithTag("Loot");
        if (lootSpawnSpot != null)
            spawnPos = lootSpawnSpot.transform.position;
        else
            spawnPos = transform.position + Vector3.up * dropHeightOffset;

        Instantiate(prefab, spawnPos, Quaternion.identity);
        Debug.Log($"{gameObject.name} dropped {prefab.name}");
    }
}