using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float speed = 7; //Make this 10 when you done lol
    Transform playerTransform;
    Vector3 target;    
    public GameObject ThisEnemy;
    


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;   // specify player as the OVR controller main camera (player)
        target = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);      // specify target as the player xyz position
    }

    // Update is called once per frame
    void Update()
    {
        // game object moves towards the target position and if reached,gets destroyed

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);  

        if(transform.position == target)
        {
            Destroy(gameObject);               
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        // If the fireball collides with the shield or the player, 
             // - The shield reflects it back towards the enemy it came from
             // - The player loses health 

        if (other.tag == "Shield")
        {
            speed = 20;
            target = new Vector3(ThisEnemy.transform.position.x, ThisEnemy.transform.position.y, ThisEnemy.transform.position.z);              
        }
        else if(other.tag == "MainCamera")
        {            
           // Reduce Health 
        }
    }

}





















// Vibrate & destroy gameobject

/* StartCoroutine(DoVibrationR());
 StartCoroutine(DoVibrationL());
 Destroy(gameObject);

 IEnumerator DoVibrationR()
 {
     // start vibration
     OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

     // wait 0.5s
     yield return new WaitForSeconds(0.25f);

     // stop vibration
     OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
 }

 IEnumerator DoVibrationL()
 {
     // start vibration
     OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

     // wait 0.5s
     yield return new WaitForSeconds(0.4f);

     // stop vibration
     OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
 }
  */
