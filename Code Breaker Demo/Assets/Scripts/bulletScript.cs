using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    GameObject police; 
    Rigidbody rb; 
    float bulletSpeed = 10; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       // rb.velocity = new Vector3(0,0,bulletSpeed);
        StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(3); 
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Police")
        {
            Debug.Log("Hit police"); 
            PoliceHealth.instance.currentHelath -= 10; 
        }
    }

}
