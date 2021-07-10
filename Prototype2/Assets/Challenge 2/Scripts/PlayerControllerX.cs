using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnInterval = 2f;
    private float spawnTime;

    void Update()
    {
        // On spacebar press, send dog
        if (Time.time > spawnTime && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnTime = Time.time + spawnInterval;
        }
    }
}
