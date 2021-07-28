using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]                                           
    public GameObject arrowPrefab;

    [Header("Bow")]
    public float grabThreshhold = 0.15f;
    public Transform startPoint;                         // start of pulling point
    public Transform End;                               // end of pulling point
    public Transform Socket;                            

    private Transform pullingHand ;                       // reference to the position of the hand pulling the string 
    private Arrow currentArrow;
    private Animator Animator;


    //create audio for bow 
    public AudioClip ArrowPullBackSound;
    public AudioClip ArrowReleaseSound;
    public float Volume;
    public AudioSource Audio;
    public bool alreadyPlayed = false;


    private float pullValue = 0.0f;

    private void Awake()
    {
        Animator = GetComponent<Animator>(); 
    }

    void Start()
    {
        StartCoroutine(CreateArrow(0.0f));                  //no delay on start for creating arrow  
        Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!pullingHand || !currentArrow)                                       // check if there is a pulling hand or a current arrow
        {
            return;             
        }

        pullValue = CalculatePull(pullingHand);                                 // set pull value
        pullValue = Mathf.Clamp(pullValue, 0.0f, 1f);                           //Make sure pull value is between 0 & 1 (because of blend tree) 
        Animator.SetFloat("Blend", pullValue);                                  // set animation 

    }

    private float CalculatePull(Transform pullHand)
    {
        Vector3 direction = End.position - startPoint.position;                                     // Set direction
        float magnitude = direction.magnitude;
        direction.Normalize();                                                  
        //calculate how far back the bow is being pulled
        Vector3 difference = pullHand.position - startPoint.position;           
        
        return Vector3.Dot(difference,direction) / magnitude;                        //DotMatrix  // check to see how much we are pulling back, so if we are pulling back on the 
    }                                                                                              // arrow in the correct direction, it shoudl be a value between 0 & 1 
                                                                                                  // Magnitude is the complete distance, difference is a small subsection 

    IEnumerator CreateArrow(float waitTime)
    {
        // wait 
        yield return new WaitForSeconds(waitTime);
        // Create arrow, make arrow a child 
        GameObject arrowObject = Instantiate(arrowPrefab,Socket);
        // Allign arrow with string position
        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;  // make rotation 0
        // Set arrow 
        currentArrow = arrowObject.GetComponent<Arrow>();
    }

    public void Pull(Transform hand)
    {
        // set distance to check if the hand is close enough to the start position of the string
        float distance = Vector3.Distance(hand.position, startPoint.position);  

        // If distance is greater than the threshhold then do nothing
        if(distance > grabThreshhold)
        {            
            return; 
        }
        // If close enough to the start point, set pulling hand to the current transform (hand) 
        pullingHand = hand;        

        //play arrow pull sound 
        Audio.PlayOneShot(ArrowPullBackSound, Volume);
        alreadyPlayed = true;
    }

    public void Release()
    {
        // Check if player is pulling back far enough
        if(pullValue > 0.25f)
        {
            FireArrow();  
        }

        //  remove pulling hand because no longer pulling string
        pullingHand = null;
        //reset pull value 
        pullValue = 0.0f;
        //reset animator 
        Animator.SetFloat("Blend", 0); 
        // if there is no current arrow, crete an arrow with a delay
        if(!currentArrow)
        {
            StartCoroutine(CreateArrow(0.25f));  
        }
        
    }

    private void FireArrow()
    {
        //fire arrow
        currentArrow.Fire(pullValue);  
        Audio.PlayOneShot(ArrowReleaseSound, Volume);
        alreadyPlayed = true;

        // when arrow is fired set current to null so that another can be spawned 
        currentArrow = null; 
    }


}
