using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanBehaviour : MonoBehaviour
{
    public float movespeed = 5f;
    public OVRInput.Button Moveleft;
    public OVRInput.Button Moveright;
    public OVRInput.Button Moveup;
    public OVRInput.Button Movedown;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (OVRInput.GetDown(Moveup) || Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        }

        else if(OVRInput.GetDown(Movedown) || Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
        }
        else if (OVRInput.GetDown(Moveright) || Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        }
        else if (OVRInput.GetDown(Moveleft) || Input.GetKeyDown(KeyCode.J))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        }
        
    }

}
