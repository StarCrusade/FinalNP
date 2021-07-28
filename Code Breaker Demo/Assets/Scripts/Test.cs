using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject item;
    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.Find("drinkingglass1");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            item.transform.position = hand.transform.position;
           // item.transform.parent = GameObject.Find("mixamorig:RightHandThumb4").transform;
            //Object.Destroy(other.gameObject);
        }
    }
}
