using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderThing : MonoBehaviour
{
   
    //GameObject glass; 


    // Start is called before the first frame update
    void Start()
    {
       
        //glass = GameObject.FindGameObjectWithTag("drinkingglass");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "drinkingglass")
        {
            Debug.Log("You touched the glass");
            // glass.transform.position = new Vector3(0, 0, 0);
           
        }
    }
}
