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
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ZoomIn());
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ZoomOut());
        }
    }

    public IEnumerator ZoomIn()
    {
        var stop = Time.deltaTime * 2.0f;
        while (myCamera.fieldOfView > minFOV)
        {
            myCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator ZoomOut()
    {
        var stop = Time.deltaTime * 2.0f;
        while (myCamera.fieldOfView < maxFOV)
        {
            myCamera.fieldOfView += zoomSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
