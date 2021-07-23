using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed; 
    public Transform[] moveSpots; 
    int randomSpot; 
    float currentWaitTime; 
    public float startWaitTime; 
   

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0,moveSpots.Length); 
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        transform.LookAt(moveSpots[randomSpot].position);

        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {

            if(currentWaitTime <= 0)
            {
                randomSpot = Random.Range(0,moveSpots.Length);
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);                                
                currentWaitTime = startWaitTime; 
            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                currentWaitTime -= Time.deltaTime;
            }
        }
    }
}
