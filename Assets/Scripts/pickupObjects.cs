using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickupObjects : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject highlightedObject;
    public GameObject stopHighlight;
    public LayerMask selectableLayer;
    public Material highlightColor;
    Ray ray;
    RaycastHit hitData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if mouse is over object
        if (Physics.Raycast(ray, out hitData, 1000, selectableLayer))
        {
            highlightedObject = hitData.transform.gameObject;
            highlightedObject.GetComponent<Renderer>().material = highlightColor;
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = hitData.transform.gameObject;
                
            }
        }

        else
        {
            stopHighlight = highlightedObject;
            stopHighlight.GetComponent<Renderer>().material = null;
            highlightedObject = null;
            //Rightclick to unselect
            if (Input.GetMouseButtonDown(2))
            {
                selectedObject = null;
            }
        }
    }
    void moveObject()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

    }
}
