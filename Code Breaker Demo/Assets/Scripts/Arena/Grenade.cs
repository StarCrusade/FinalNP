using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float timer = 2;
    float countdown;
    float radius = 20;
    float force = 2000;    
    bool hasExploded;
    
    public bool takeDamage = false;

    [SerializeField] GameObject explosionParticles;

  
    // Start is called before the first frame update
    void Start()
    {        
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "Floor")
        {
            if (countdown <= 0 && !hasExploded)
            {
                Explode();             
            }
        }
    }

    void Explode()
    {
        GameObject spawnedParticle = Instantiate(explosionParticles, transform.position, transform.rotation);
        Destroy(spawnedParticle, 1);
        

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);  // Find objects with colliders within the radius 
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();      

            if (rb != null)
            {               
                rb.AddExplosionForce(force, transform.position, radius);
            }          

            MonoBehaviour[] behaviours =  nearbyObject.gameObject.GetComponents<MonoBehaviour>();     

            foreach (MonoBehaviour behaviour in behaviours)
            {
                if (behaviour is IDamagable)
                {
                    IDamagable damagable = (IDamagable)behaviour;
                    damagable.Damage(1);

                    break;
                }
            }
        }

        

        hasExploded = true;
        Destroy(gameObject); 
    }

    
}
