using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class ArenaFlyingEnemy : MonoBehaviour, IDamagable
{
    GameObject Target;
    private NavMeshAgent nma;


    public GameObject bullet;
    public GameObject FirePoint;
    GameObject enemy;
   
    float distance;
    float TimebetweenShots;
    float startTBS = 3f;

    public GameObject explosionParticles;
  

    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("MainCamera");        
        enemy = this.gameObject;
        TimebetweenShots = startTBS;
       
    }

    // Update is called once per frame
    void Update()
    {        
        Destination();

        Vector3 direction = Target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;


        distance = Vector3.Distance(enemy.transform.position, Target.transform.position);

        if (distance < 50)
        {
            if (TimebetweenShots <= 0)
            {
                Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
                TimebetweenShots = startTBS;
            }
            else
            {
                TimebetweenShots -= Time.deltaTime;
            }
        }
    }

    void Destination()
    {
        nma.SetDestination(Target.transform.position);
    }

    public void Damage(int amount)
    {
        if (amount >= 5)
        {
            GameObject spawnedParticle = Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(spawnedParticle, 1);           
            Destroy(gameObject);
        }
    }
}
