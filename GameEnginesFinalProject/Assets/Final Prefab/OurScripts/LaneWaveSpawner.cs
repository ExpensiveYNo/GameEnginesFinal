using System.Collections;
using UnityEngine;

public class LaneWaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public int totalWaves = 5;
    public int enemiesPerWave = 6;                  // Increases each wave
    public int enemiesPerWaveIncrement = 2;         // How many more enemies each wave adds
    public float timeBetweenWaves = 20f;            // Seconds between waves
    public float timeBetweenSpawns = 1f;            // Seconds between each enemy spawning in a wave

    [Header("Spawn Settings")]
    public GameObject[] enemyPrefabs;               // Drag enemy prefabs here
    public Transform[] laneSpawnPoints;             // One spawn point per lane (start of each lane)
    public float spawnHeightOffset = 0.5f;

    private int currentWave = 0;
    private int totalEnemiesSpawned = 0;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        while (currentWave < totalWaves)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            currentWave++;
            int enemiesToSpawn = enemiesPerWave + (currentWave - 1) * enemiesPerWaveIncrement;

            Debug.Log($"Wave {currentWave} starting — spawning {enemiesToSpawn} enemies");

            yield return StartCoroutine(SpawnWave(enemiesToSpawn));
        }

        Debug.Log("All waves complete!");
    }

    IEnumerator SpawnWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
            totalEnemiesSpawned++;
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || laneSpawnPoints.Length == 0)
        {
            Debug.LogWarning("LaneWaveSpawner: Missing prefabs or spawn points!");
            return;
        }

        // Pick a random lane spawn point and random enemy prefab
        Transform spawnPoint = laneSpawnPoints[Random.Range(0, laneSpawnPoints.Length)];
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Vector3 spawnPos = spawnPoint.position + Vector3.up * spawnHeightOffset;
        Instantiate(prefab, spawnPos, spawnPoint.rotation);
    }
}
