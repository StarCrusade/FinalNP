using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject alienbullet;
    public float MinFireRate = 1.0f;
    public float MaxFireRate = 10.0f;
    public float BaseFireWaitTime = 1.0f;
    



    void Start()
    {
       BaseFireWaitTime = BaseFireWaitTime + Random.Range(MinFireRate, MaxFireRate);
    }

    private void FixedUpdate()
    {
        if(Time.time > BaseFireWaitTime)
        {
            BaseFireWaitTime = BaseFireWaitTime + Random.Range(MinFireRate, MaxFireRate);
            Instantiate(alienbullet, transform.position, Quaternion.identity);
        }
    }

    
        
    
}
