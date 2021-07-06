using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 100f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
