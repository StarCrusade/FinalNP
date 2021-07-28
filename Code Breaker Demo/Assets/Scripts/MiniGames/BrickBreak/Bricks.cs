using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject particles; 

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);        
    }
}
