using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashspawner : MonoBehaviour
{
    public GameObject[] trash;


    // Start is called before the first frame update
    void Start()
    {
        //dictates the array of trash prefabs
        trash = new GameObject[5];
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
