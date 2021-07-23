using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceHealth : MonoBehaviour
{
    public float maxHealth = 100f; 
    public float currentHelath; 

    public static PoliceHealth instance;





    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }
        currentHelath = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.H))
        {
            currentHelath -= 10;
            Debug.Log(currentHelath + "Current Health");  
        }

        if(currentHelath <= 0)
        {
            Destroy(this.gameObject); 
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);


        if(other.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet did damage"); 
        }
    }
}
