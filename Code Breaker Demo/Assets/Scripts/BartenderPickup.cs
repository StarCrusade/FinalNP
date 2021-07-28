using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderPickup : MonoBehaviour
{
    GameObject item;
    public GameObject hand;
    public GameObject question;
    public static bool disabled = true;


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
        if (other.tag == ("HandCollider"))
        {
            item.transform.position = hand.transform.position;
            this.transform.parent = GameObject.Find("mixamorig:RightHandThumb4").transform;

            if (disabled)
            {
                question.SetActive(true);
                disabled = false;
            }
            

        }
    }
}
