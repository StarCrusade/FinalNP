using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameObject theBullet;   
    public OVRInput.Button Moveright;
    public OVRInput.Button Moveleft;
    public OVRInput.Button shoot;


    private void FixedUpdate()
    {
        if (OVRInput.GetDown(Moveleft) || Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        }
        if (OVRInput.GetDown(Moveright) || Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shoot) || Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(theBullet, transform.position , Quaternion.identity);
        }
    }
    
        
    

}
