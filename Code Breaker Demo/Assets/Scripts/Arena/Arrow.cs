using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 2000.0f;
    public Transform Tip = null;
    private Rigidbody rb = null;
    private bool IsStopped = true;
    private Vector3 lastPosition = Vector3.zero;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        lastPosition = transform.position;  // 
    }

    private void FixedUpdate()
    {
        if (IsStopped)                      // check if arrow is not flying through the air
        {
            return;
        }

        // Rotate arrow in the direction that the velocity is going in 
        rb.MoveRotation(Quaternion.LookRotation(rb.velocity, transform.up));

        // Collision 
        RaycastHit hit; 
        if (Physics.Linecast(lastPosition, Tip.position, out hit))  // using line cast because, if object is moving really fast,  
        {                                                           //if there is no dynamic collision that is always checking, 
                                                                    //it can pass through objects.Turning up physics could hinder performance
            Stop(hit.collider.gameObject);
        }

        lastPosition = Tip.position;
    }
    private void Stop(GameObject hitObject)
    {
        IsStopped = true;

        transform.parent = hitObject.transform;                     // Make rhe arrow a child of the object it hit (make it stick) 


        // turn gravity off
        rb.isKinematic = true;          
        rb.useGravity = false;


        CheckForDamage(hitObject);                                  //check if object hit gets damaged 
    }

    private void CheckForDamage(GameObject hitObject) 
    {
        MonoBehaviour[] behaviours = hitObject.GetComponents<MonoBehaviour>();     // collect all the components attached to this object 

        foreach (MonoBehaviour behaviour in behaviours)
        {
            if(behaviour is IDamagable)
            {
                IDamagable damagable = (IDamagable)behaviour;
                damagable.Damage(5);

                break;
            }
        }
    }

    public void Fire(float pullValue)
    {
        lastPosition = transform.position;
        IsStopped = false;
        // make arrow detach from bow(parent) 
        transform.parent = null;
        // Turn on gravity
        rb.isKinematic = false;
        rb.useGravity = true;
        // add force so it flys forward, affected by how far string is pulled and the speed
        rb.AddForce(transform.forward * (pullValue * speed));
        //Destroy arrow after 5 seconds 
        Destroy(gameObject, 5.0f);
    }

}
