using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
            
        }
        if (other.tag == "Alien")
        {
            Destroy(gameObject);    
            Object.Destroy(other.gameObject);
        }
        if (other.tag == "Astroid")
        {
            Destroy(gameObject);
            Object.Destroy(other.gameObject);
        }




    }
    
}
