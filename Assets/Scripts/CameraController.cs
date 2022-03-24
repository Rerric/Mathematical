using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera myCamera;

    public float zoomSpeed;

    public float maxFOV;
    public float minFOV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            myCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            if (myCamera.fieldOfView < minFOV)
            {
                myCamera.fieldOfView = minFOV;
            }
        }

        if (Input.GetMouseButton(1))
        {
            myCamera.fieldOfView += zoomSpeed * Time.deltaTime;
            if (myCamera.fieldOfView > maxFOV)
            {
                myCamera.fieldOfView = maxFOV;
            }
        }
    }
}
