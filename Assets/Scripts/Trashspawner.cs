using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashspawner : MonoBehaviour
{
    public GameObject[] trashspawner;

    public int ChooseSide = 0;
    public Addictionlevel AddictScript;
    Vector3 spawnPos;
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
              

                Invoke("SpawnSides", 2);
               
                Instantiate(trashspawner[index], spawnPos, trashspawner[index].transform.rotation);
                AddictScript.messy -= 1;
                Debug.Log("trashWorking");
            }
        }
    }
    //Chooses which side of desk to spawn trash
    void SpawnSides()
    {
        ChooseSide = Random.Range(0, 2);
        if (ChooseSide >= 1)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-15, -5), 2.5f, Random.Range(6, 14));
            Debug.Log("check");
        }
        if(ChooseSide==0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(7, 13), 2.5f, Random.Range(6, 14));
            Debug.Log("other");
        }
    }
}
