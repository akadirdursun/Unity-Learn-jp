using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerControllerScript.IsGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
    }
}
