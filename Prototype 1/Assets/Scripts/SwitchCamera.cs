using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private Camera topCamera;
    [SerializeField] private Camera driverCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();
        }    
    }

    private void ChangeCamera()
    {
        topCamera.gameObject.SetActive(!topCamera.gameObject.activeSelf);
        driverCamera.gameObject.SetActive(!driverCamera.gameObject.activeSelf);
    }
}
