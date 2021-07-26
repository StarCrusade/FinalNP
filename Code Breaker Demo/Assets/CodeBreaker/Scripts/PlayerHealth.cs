using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHelath;
    public Text Healthtext;
    public static PlayerHealth instance;





    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        currentHelath = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Healthtext.text = "Health: " + currentHelath;

        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHelath -= 10;
            Debug.Log(currentHelath + "Current Health");
        }

        if (currentHelath <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);


        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet did damage");
        }
    }
}
