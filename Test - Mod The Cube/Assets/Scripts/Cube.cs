using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer Renderer;
    private Material material;
    private Vector3[] rotateAngle = { Vector3.right, Vector3.up, Vector3.forward };
    private int angleIndex;
    private float rotationSpeed;
    
    void Start()
    {
        material = Renderer.material;

        angleIndex = Random.Range(0, rotateAngle.Length);
        rotationSpeed = Random.Range(15f, 50f);

        InvokeRepeating("ChangeToRandomColor", 1f, 2f);
        InvokeRepeating("ChangeTheScaleRandomly", 1f, 2f);
        InvokeRepeating("ChangeThePositionRandomly", 1f, 2f);
    }

    void Update()
    {        
        RotateRandomly();
    }

    private void ChangeToRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        float a = Random.Range(0.2f, 1f);

        material.color = new Color(r, g, b, a);
    }

    private void ChangeThePositionRandomly()
    {
        float x = Random.Range(0f, 4f);
        float y = Random.Range(-7f, 7f);
        float z = Random.Range(-5f, 5f);

        transform.position = new Vector3(x, y, z);
    }

    private void ChangeTheScaleRandomly()
    {
        transform.localScale = Vector3.one * Random.Range(1.1f, 3f);
    }

    private void RotateRandomly()
    {
        transform.Rotate(rotateAngle[angleIndex] * rotationSpeed * Time.deltaTime);
    }
}
