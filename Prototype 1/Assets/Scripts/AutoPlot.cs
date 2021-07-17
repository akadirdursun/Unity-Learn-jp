using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlot : MonoBehaviour
{
    [SerializeField] private float speed = 7f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
