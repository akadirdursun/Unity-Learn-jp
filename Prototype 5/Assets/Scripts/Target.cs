using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    private Rigidbody targetRB;
    private GameManager gameManager;

    private float xSpawnRange = 4f;
    private float ySpawnPos = -2f;
    private float minForce = 10f;
    private float maxForce = 15f;
    private float torqueValue = 10f;


    private void Awake()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        transform.position = RandomSpawnPosition();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTarque(), RandomTarque(), RandomTarque(), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        if (gameManager.IsGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("BadTarget"))
            gameManager.GameOver();

        Destroy(gameObject);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTarque()
    {
        return Random.Range(-torqueValue, torqueValue);
    }
}
