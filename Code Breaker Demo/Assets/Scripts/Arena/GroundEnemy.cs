using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class GroundEnemy : MonoBehaviour
{
    GameObject Target;
    private NavMeshAgent nma;
    Animator anim;

   public bool attacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(Target.transform.position);
        Vector3 direction = Target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        float dist = Vector3.Distance(nma.transform.position, Target.transform.position);   
        

        if(dist <= 2)
        {
            attacking = true;
            nma.updatePosition = false;
            anim.SetBool("IsWalking", false);            
            anim.SetBool("IsSwiping", true);
                              
        }
        else if (dist >= 3.5)
        {
            attacking = false;
            nma.updatePosition = true;            
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsSwiping", false);            
        }

    }


    IEnumerator FollowDelay()
    {
        yield return new WaitForSeconds(2);        
        
    }
}
