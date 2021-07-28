using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Monster; 

    public void Spawn()
    {
       
        Instantiate(Monster, SpawnPoint.transform.position, Quaternion.identity);        
    }

}
