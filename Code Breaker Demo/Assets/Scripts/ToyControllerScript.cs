using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToyControllerScript : MonoBehaviour
{
    public Camera cam;

    private Transform camTransform; 
    private CharacterController controller;
    private Animator anim;

    float movementSpeed = 3f;
    float currentSpeed = 0;
    float speedSmoothVelocity = 0f;
    float speedSmoothTime = 0.1f;
    float rotationSpeed = 0.1f;
    float gravity = 3f;

   
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        camTransform = cam.transform;        
    }

    void Update()
    {      
       Move();           
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Oculus_GearVR_LThumbstickX"), Input.GetAxisRaw("Oculus_GearVR_LThumbstickY"));
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;

        Vector3 gravityVector = Vector3.zero;

        if(!controller.isGrounded)
        {
            gravityVector.y -= gravity; 
        }

        if(desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection),rotationSpeed);
        }

        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed,targetSpeed, ref speedSmoothVelocity,speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);

        anim.SetFloat("MovementSpeed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
    }




}
