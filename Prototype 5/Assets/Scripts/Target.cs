using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    private Rigidbody targetRB;

    private float minForce = 10f;
    private float maxForce = 15f;
    private float torqueValue = 10f;

    private bool isGameActive = true;

    private void Awake()
    {
        targetRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTarque(), RandomTarque(), RandomTarque(), ForceMode.Impulse);
    }

    private void OnEnable()
    {
        StaticEvents.GameOver += IsGameOver;
    }

    private void OnDisable()
    {
        StaticEvents.GameOver -= IsGameOver;
    }

    private void IsGameOver()
    {
        isGameActive = false;
    }

    private void OnMouseDown()
    {
        if (isGameActive)
        {
            StaticEvents.AddScore?.Invoke(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }           
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
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
