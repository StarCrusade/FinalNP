using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forward : MonoBehaviour
{
    GameObject cube;
   
    public GameObject hand;
    Transform han;
        
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("HandCollider"))
        {
            cube.transform.position = hand.transform.position;
            this.transform.parent = GameObject.Find("mixamorig:RightHandThumb4").transform;
        }
    }
}
