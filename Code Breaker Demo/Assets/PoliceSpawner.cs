using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    //public GameObject[] police; 
    public GameObject police; 
    float timer;
    float timer2;

    int policeCount;  
    int policeParkCount; 

    float xPosition;
    float zPosition; 

    float xPosition2;
    float zPosition2; 
    float policespawn; 


    // Start is called before the first frame update
    void Start()
    {
        policeCount = 0;
        timer = 0;  
        timer2 = 0; 
      
      //  policespawn = Random.Range(0, police.Length);

    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime; 
        timer2 += 1 * Time.deltaTime; 

       // Debug.Log(timer + "This is the timer");
        if(policeCount < 6 && timer >= 10)
        {
            timer = 0; 
            policeCount ++; 
            // spawn police model 
              xPosition = Random.Range(-37,24); 
                zPosition = Random.Range(-25,-5);
            Instantiate(police,new Vector3(xPosition,0,zPosition), Quaternion.identity);

        }

        if(policeParkCount < 4 && timer2 >= 10)
        {
            timer2 = 0; 
            policeParkCount ++; 
            // spawn police model 
            xPosition2 = Random.Range(-35,21); 
            zPosition2 = Random.Range(19,40);
            Instantiate(police,new Vector3(xPosition2,0,zPosition2), Quaternion.identity);

        }
    }
}
