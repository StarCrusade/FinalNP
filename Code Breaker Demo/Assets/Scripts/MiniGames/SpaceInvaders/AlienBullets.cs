using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullets : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
     {
         if(other.tag == "Player")
         {
             Destroy(gameObject);
             Object.Destroy(other.gameObject);
         }
         else if(other.tag == "Wall")
         {
             Destroy(gameObject);       

         }


     }
   

}
