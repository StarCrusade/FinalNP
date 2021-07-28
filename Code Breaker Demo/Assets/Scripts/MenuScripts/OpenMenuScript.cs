using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuScript : MonoBehaviour
{
    public GameObject button;
    public GameObject pointer;
    //public GameObject Glow; 
    public OVRInput.Button MenuButton;
    public static bool disabled = true;

    private void Start()
    {
        disabled = true;
        button.SetActive(false);
        pointer.SetActive(false);
       // Glow.SetActive(false);
    }
    private void Update()
    {
        Menu(); 
    }

    void Menu()
    {
        if (OVRInput.GetDown(MenuButton) && disabled)
        {
            disabled = false;
            pointer.SetActive(true); 
            button.SetActive(true);
           // Glow.SetActive(true);            
        }
        else if (OVRInput.GetDown(MenuButton) && !disabled)
        {
            pointer.SetActive(false);
            button.SetActive(false);
           // Glow.SetActive(false);
            disabled = true;
        }
    }
}
