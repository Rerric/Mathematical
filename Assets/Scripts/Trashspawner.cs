using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashspawner : MonoBehaviour
{
    public GameObject[] trashspawner;
    private Addictionlevel Addictionlevelscript;
    public int ChooseSide = 0;

    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {

        Addictionlevelscript = GameObject.Find("addictcheck").GetComponent<addiction;

       if (LevelComplete==true)
        {
          
            Invoke("SpawnTrash", 2);
        }
    }

    // Update is called once per frame
   void SpawnTrash()
    {
        int index = Random.Range(0, trashspawner.Length);
        //refers to Addictionlevel code
        if (addiction<0f)
        {
            //amount of messages ignored corresponds to amount of trash 'messy'
            while (messy<= 1)
            {
               ;
                //chooses on which side of desk to spawn
                ChooseSide = Random.Range(0, 2);

                if (ChooseSide != 0)
                {
                    Vector3 spawnPos = new Vector3(Random.Range(-15f, -5f), 2.5f, Random.Range(6f, 14f));
                }
                else
                {
                    Vector3 spawnPos = new Vector3(Random.Range(7f, 13f), 2.5f, Random.Range(6f, 14f));
                }
                Instantiate(trashspawner[index], spawnPos, trashspawner[index].transform.rotation);
                messy = -1;
            }
        }
    }
}
