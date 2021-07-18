using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnTime = 0.5f;

    private float xSpawnRange = 4f;
    private float ySpawnPos = -2f;    

    private void OnEnable()
    {
        StaticEvents.StartTheGame += StartToSpawn;
        StaticEvents.GameOver += StopSpawning;
    }

    private void OnDisable()
    {
        StaticEvents.StartTheGame -= StartToSpawn;
        StaticEvents.GameOver -= StopSpawning;
    }

    private void StartToSpawn(float difficulty)
    {        
        spawnTime *= difficulty;
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        Debug.Log("Spawn Time " + spawnTime);
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index], RandomSpawnPosition(), targets[index].transform.rotation);
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos);
    }

    private void StopSpawning()
    {
        //isGameActive = false;
        StopCoroutine(SpawnTarget());
    }
}
