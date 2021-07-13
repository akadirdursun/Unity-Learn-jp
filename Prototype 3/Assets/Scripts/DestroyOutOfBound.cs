using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float leftBound = -15f;

    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }    
    }
}
