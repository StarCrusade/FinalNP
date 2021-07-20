using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
     public GameObject bullet; 
     public GameObject bulletPosition;  
     public float bulletSpeed; 
     GameObject bulletThing;     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bulletThing = Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
            bulletThing.transform.rotation = Quaternion.Euler(90,0,0);

            Debug.Log("I've fired the flip[pin gun");
        }
    }
}
