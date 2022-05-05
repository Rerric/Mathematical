using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashspawner : MonoBehaviour
{
    public GameObject[] trashspawner;
    public Vector3 spawnPos = new Vector3(0, 0, 0);
    public int ChooseSide = 0;
    public Addictionlevel AddictScript;

    // Start is called before the first frame update
    void Start()
    {

        AddictScript = GameObject.Find("Addictcheck").GetComponent<Addictionlevel>();


       //if (LevelComplete==true)
        {
          
            Invoke("SpawnTrash",2);

        }
    }

    //spawns trash
   void SpawnTrash()
    {

        
        if (AddictScript.addiction > 0)
        {

            
            while (AddictScript.messy >= 1)
            {
                int index = Random.Range(0, trashspawner.Length);
                //chooses on which side of desk to spawn


                
                ChooseSide = Random.Range(0, 2);
                if (ChooseSide > 0)
                {
                    spawnPos = new Vector3(Random.Range(-15, -5), 2.5f, Random.Range(6, 14));
                    Debug.Log("leftchosen");
                }
                else
                {
                     spawnPos = new Vector3(Random.Range(7, 13), 2.5f, Random.Range(6, 14));
                    Debug.Log("rightchosen");
                }

                Instantiate(trashspawner[index], spawnPos, trashspawner[index].transform.rotation);
                AddictScript.messy -= 1;
                Debug.Log("trashWorking");
            }
        }
    }

   
    
}
