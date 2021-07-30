using UnityEngine;

namespace ClickyMause.Targets
{
    public abstract class AbstractTarget : MonoBehaviour
    {
        [SerializeField] protected int pointValue;
        [SerializeField] protected ParticleSystem explosionParticle;
        [SerializeField] protected PlayerData playerData;

        protected Rigidbody targetRB;

        protected float minForce = 10f;
        protected float maxForce = 15f;
        protected float torqueValue = 10f;

        protected bool isGameActive = true;

        private void Awake()
        {
            targetRB = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            StaticEvents.GameOver += IsGameOver;
            targetRB.AddForce(RandomForce(), ForceMode.Impulse);
            targetRB.AddTorque(RandomTarque(), RandomTarque(), RandomTarque(), ForceMode.Impulse);
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
                playerData.AddScore(pointValue);
                TargetActions();
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //Destroy(gameObject);
            targetRB.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minForce, maxForce);
        }

        private float RandomTarque()
        {
            return Random.Range(-torqueValue, torqueValue);
        }

        protected virtual void TargetActions()
        {
        }
    }
}