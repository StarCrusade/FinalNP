using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeMovement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public GameObject bullet;
    public GameObject bulletSpawnPoint; 
    Vector3 playerTransform; 
    public float speed = 2; 
    public Transform[] moveSpots; 
    int randomSpot; 
    float currentWaitTime; 
    public float startWaitTime; 
    float distanceFromPlayer;
    bool isFiring = false; 

    float bulletCounter; 

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
        bulletCounter += 1 * Time.deltaTime;
        distanceFromPlayer = Vector3.Distance(player.transform.position,this.transform.position); 
        if(distanceFromPlayer > 7)
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
        else if(distanceFromPlayer <= 7)
        {
            isFiring = true; 
            transform.position = this.transform.position; 
            transform.LookAt(player.transform.position);
            anim.SetBool("isShooting", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
                 
            if(bulletCounter > 1)
            {
                bulletCounter = 0; 
                GameObject Bullets = Instantiate(bullet, bulletSpawnPoint.transform.position, bullet.transform.rotation);   
                //Vector3 dir = (Bullets.transform.position - player.transform.position).normalized;
                
            }     
            
            
            
        }
    }
   
 }
