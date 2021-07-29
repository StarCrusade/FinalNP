using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeBulletScript : MonoBehaviour
{
    GameObject player; 
    Rigidbody rb; 
    float speed = 7;
    Vector3 moveDirection; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized * speed; 
        rb.velocity = new Vector3(moveDirection.x,moveDirection.y,moveDirection.z); 
    }

}
