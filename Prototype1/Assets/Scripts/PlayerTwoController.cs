using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 10f;
    private float horizontalInput;
    private float forwardInput;
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");

        transform.Translate(Vector3.forward * speed * forwardInput * Time.deltaTime);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
