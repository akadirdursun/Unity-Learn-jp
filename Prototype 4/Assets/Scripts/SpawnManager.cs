using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private GameObject powerupPrefab;

    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNumber = 1;

    private void Start()
    {
        WaveSpawn(waveNumber);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {            
            WaveSpawn(waveNumber);
        }
    }

    private void WaveSpawn(int enemiesToSpawn)
    {
        Instantiate(powerupPrefab, GenerateRandomSpawnPosition(), powerupPrefab.transform.rotation);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerateRandomSpawnPosition(), enemyPrefabs.transform.rotation);
        }
        waveNumber++;
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
