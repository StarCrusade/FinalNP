using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject bulletPosition2;
    public GameObject bulletPosition3;
    public GameObject bulletPosition4;
    public GameObject bulletPosition5;
    public int maxAmmo = 4;
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
         if(Input.GetMouseButtonDown(0))
        {
            if(currentAmmo > 0)
            {
            Instantiate(bullet, bulletPosition.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition2.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition3.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition4.transform.position, Quaternion.identity);
            Instantiate(bullet, bulletPosition5.transform.position, Quaternion.identity);
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
