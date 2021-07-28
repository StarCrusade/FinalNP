using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit; 

        if(Physics.Raycast(transform.position,transform.forward,out hit,1,layer) )
        {
            
            if(Vector3.Angle(transform.position-previousPos,hit.transform.up)>130) 
            {
                StartCoroutine(DoVibrationR());
                StartCoroutine(DoVibrationL());
                Destroy(hit.transform.gameObject);
            }
        }
        previousPos = transform.position; 


    }

    IEnumerator DoVibrationR()
    {
        // start vibration
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

        // wait 0.5s
        yield return new WaitForSeconds(0.25f);

        // stop vibration
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }

    IEnumerator DoVibrationL()
    {
        // start vibration
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

        // wait 0.5s
        yield return new WaitForSeconds(0.25f);

        // stop vibration
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }

}
