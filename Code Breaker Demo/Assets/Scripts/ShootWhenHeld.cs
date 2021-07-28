using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWhenHeld : MonoBehaviour
{
    private SimpleShoot shoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootButton;
    public OVRInput.Button Rreload;
    public OVRInput.Button Lreload;
    public OVRGrabber Ltouch;
    public OVRGrabber Rtouch;
    public int Currentbullets = 10;
    public int maxbullets = 10;
    public Text bulletText;



    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        bulletText.text = Currentbullets.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


}
