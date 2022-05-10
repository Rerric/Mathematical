using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashpickup : MonoBehaviour

{
    private Color MouseEnters = Color.white;
    private Color MouseExits = Color.black;
    public bool dragging = false;
    public float distance;
    public Vector3 startDist;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //triggers whenever mouse enters the object
    void OnMouseEnter()
    {
        //GetComponent<Renderer>(Color);
       //renderer.material.color = mouseOverColor;
    }
    //triggers when mouse isn't present
    void OnMouseExit()
    {
        

    }
     void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }
    void OnMouseUp()
    {
        dragging = false;
    }
    // Update is called once per frame
    void Update()
    {
        //make it so object is unable to go through table or front and back border
        //lock z cordinate
        //fix cursortracking
        //something with Physics.Raycast Input.mousePosition Camera.ScreenToWorldPoint Camera.ScreenPointToRay Rigidbody.move.position dynamic/speculative continuos
        if (dragging)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            GetComponent<Rigidbody>().position = rayPoint + startDist;
            
            
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

    }
   
        
    
}
