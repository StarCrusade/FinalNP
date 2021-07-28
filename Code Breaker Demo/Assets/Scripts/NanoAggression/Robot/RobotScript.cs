using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    public float visible = -3.46f;
    public float hidden = -5.386056f;
    private Vector3 newXYZposition;  
    public float speed = 4;
    public float hidetimer = 2f;    
    public GameObject fireBall;
    public Transform mouth;
    public bool showing = false; 
   
    private void Awake()
    {        
        Hide();                         // calls the hide function on start of the game 
        transform.localPosition = newXYZposition;       //set original position to new position 
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, newXYZposition, Time.deltaTime * speed);
        
        hidetimer -= Time.deltaTime;  

        if (hidetimer <= 0)  // if timer is less or equals 0, call hide function 
        {
            Hide();
        }
    }

    public void Hide()
    {
        // position is set to hidden position (on the X axis)  
        newXYZposition = new Vector3(hidden, transform.localPosition.y, transform.localPosition.z);  
        showing = false; 
    }
    public void Show()
    {
        showing = true;
        // set position to visible position (on the X axis)
        newXYZposition = new Vector3(visible, transform.localPosition.y, transform.localPosition.z);   
        hidetimer = 2f;
        // create fireball at robot mouth position
        GameObject bullet = Instantiate(fireBall, mouth.position , Quaternion.identity);
        // find enemy that instanciated fireball and set as a gameobject
        bullet.GetComponent<FollowPlayer>().ThisEnemy = gameObject;  
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Fireball")
        {
            if(showing == true)
            {
                //increase score by 10, destroy the fireball,robot goes back into hide position
                NanoAggressionScoreSystem.theScore += 10;     
                Destroy(other.gameObject);
                Hide();
            }                          
        }
    }
}
