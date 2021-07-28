using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMove : MonoBehaviour
{
    GameObject astroid;
    public GameObject[] enemies;
    public Transform[] points;
    

    void Start()
    {
        astroid = GameObject.FindGameObjectWithTag("Astroid");
    }
     void Update()
    {        
        GameObject astroid = Instantiate(enemies[Random.Range(0, 1)], points[Random.Range(0, 10)]);  // random cube, random position 
        astroid.transform.localPosition = Vector3.zero;
        astroid.transform.Rotate(transform.forward, 90 * Random.Range(0, 2));
         
    }
}
