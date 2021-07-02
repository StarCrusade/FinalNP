using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController Controller; //Ref to the Character controller. CharacterController allows you to easily do movement constrained by collisions without having to deal with a rigidbody.
    public Transform cam;// ref to cam

    public float speed = 6f; // Speed variable

    public float turnsmoothTime = 0.1f; //smoothing turn variable
    float turnsmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");// returns the value on the horizontal axis without any smoothing filtering 
        float vertical = Input.GetAxisRaw("Vertical");// returns the value on the Vertical axis without any smoothing filtering
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;//this allows for movement on the X and Z axis not the Y.
        //normalised so holding multiple keys doesn't increase speed
        if (direction.magnitude >= 0.1f)// to check if there is movement in any direction
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)/*returns the angle from the x/y axis  */ * Mathf.Rad2Deg + cam.eulerAngles.y;//adds the rotation of the camera on the Y axis
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnsmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;// the addition of * Vector3.forward turns the rotation into a direction
            // gives you the direction you want to move with the roation of the camera
            Controller.Move(movedir.normalized * speed * Time.deltaTime /*makes it framerate independent*/);
        }
    }
}
