using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private SnakePlayerController playerController;
    private int horizontal = 0, vertical = 0;
    public OVRInput.Button Up;
    public OVRInput.Button Down;
    public OVRInput.Button Left;
    public OVRInput.Button Right;



    public enum Axis
    {
        Horizontal,
        Vertical
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<SnakePlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = 0;
        vertical = 0;
        GetKeyboardInput();
        SetMovement();
    }
    void GetKeyboardInput()
    {
        // horizontal =(int)Input.GetAxisRaw("Horizontal");
        //vertical= (int)Input.GetAxisRaw("Vertical");

        horizontal = GetAxisRaw(Axis.Horizontal);
        vertical = GetAxisRaw(Axis.Vertical);

        if(horizontal != 0)
        {
            vertical = 0;
        }
    }
    void SetMovement()
    {
        if(vertical !=0)
        {
            
            playerController.SetInputDirection((vertical == 1) ? PlayerDirection.LEFT : PlayerDirection.RIGHT);
        }
        else if (horizontal != 0)
        {
            
            playerController.SetInputDirection((horizontal == 1) ? PlayerDirection.UP : PlayerDirection.DOWN);
        }
    }

    int GetAxisRaw(Axis axis)
    {
        if(axis == Axis.Horizontal)
        {
            bool left = OVRInput.GetDown(Left);    //This one is left
            bool right = OVRInput.GetDown(Right);   //This one is right

            if(left)
            {
                return -1; 
            }
            if (right)
            {
                return 1;
            }

            return 0; 
        }
        else if (axis == Axis.Vertical)
        {
            bool up = OVRInput.GetDown(Up);    //This one is up
            bool down = OVRInput.GetDown(Down);   //This one is down

            if (up)
            {
                return 1;
            }
            if (down)
            {
                return -1;
            }
            return 0;
        }
        return 0;
    }
}
