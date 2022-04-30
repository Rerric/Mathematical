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

        //checks message
        addiction = -0.6f;
        
        //makes sure that addiction never goes below 0
        if(addiction>=0f)
        {
            addiction = 0f;
        }

        //final convert into messy
        if (LevelComplete == true)
        {
            messy = (int)addiction;

        }
    }
}
   


