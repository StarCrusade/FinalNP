using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMovementandFire : MonoBehaviour
{
    public GameObject theBullet;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.J))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Astroid")
        {
            Destroy(gameObject);
        }
    }
   
}
