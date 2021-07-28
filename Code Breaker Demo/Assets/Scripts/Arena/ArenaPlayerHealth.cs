using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaPlayerHealth : MonoBehaviour
{
    public Slider HealthSlider;
    int maxHealth = 100;
    public int currentHealth;
    public OVRInput.Button abutton;

    bool hdecrease; 

    // Start is called before the first frame update
    void Start()
    {        
        currentHealth = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider.value = currentHealth;

        if (!hdecrease)
        {
            hdecrease = true;
            StartCoroutine(DecreaseHealth());
        }
        if(currentHealth > 100)
        {
            currentHealth = 100; 
        }
        
    }

    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSeconds(3);
        currentHealth -= 1;
        hdecrease = false; 
    }
    
}
