using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject Gun;
    float xPos; 
    float zPos; 
    public bool isSpawned = false; 
    

    // Update is called once per frame
    void Update()
    {
        xPos = Random.Range(-51,34); 
        zPos = Random.Range(-17, 50);  
        if(!isSpawned)
        {
            Instantiate(Gun, new Vector3(xPos,0,zPos), Quaternion.identity);
            isSpawned = true; 
        }
    }
}
