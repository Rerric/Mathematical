using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addictionlevel : MonoBehaviour
{
    public float addiction = 0;
    public int messy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ignore message
        addiction = +0.8f;

        //adress message
        addiction = -0.6f;
        
        if(addiction>=0f)
        {
            addiction = 0f;
        }
        if (LevelComplete==true)
        {
            messy= (int)addiction;
           
        }
    }
}
