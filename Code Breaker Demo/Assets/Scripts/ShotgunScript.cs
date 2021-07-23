using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject bulletPosition2;
    public GameObject bulletPosition3;
    public GameObject bulletPosition4;
    public GameObject bulletPosition5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition2.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition3.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition4.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition5.transform.position, Quaternion.identity);
            


            //bulletThing.transform.rotation = Quaternion.Euler(90,0,0);

            Debug.Log("I've fired the flip[pin gun");
        }
    }
}
