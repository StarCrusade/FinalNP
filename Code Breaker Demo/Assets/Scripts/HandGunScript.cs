using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandGunScript : MonoBehaviour
{
    public GameObject bullet; 
    public GameObject bulletPosition;  
    public int maxAmmo = 8;
    public int currentAmmo;
    public Text Ammotext;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Ammotext.text = "Ammo: " + currentAmmo;
         if(Input.GetMouseButtonDown(0))
        {
            //Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
            if(currentAmmo > 0)
            {
                Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
                currentAmmo--;
            }
            else
            {
                Debug.Log("no ammo left");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
        }
    }
}
