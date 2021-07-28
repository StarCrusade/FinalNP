using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldScript : MonoBehaviour
{
    GameObject Toy;
    OVRPlayerController player; 


    private void Start()
    {
        Toy = GameObject.FindGameObjectWithTag("Toy");
        Toy.SetActive(false);
    }

    public void Spawn()
    {
        Toy.SetActive(true);
        player.EnableLinearMovement = false;

    }
        

     
   


}
