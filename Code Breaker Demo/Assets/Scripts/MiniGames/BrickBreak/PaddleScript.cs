using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float paddleSpeed = 2;
    private Vector3 playerPos = new Vector3(61.42f, -7.41f, 4.64f); 

  
    // Update is called once per frame
    void Update()
    {
        float xpos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xpos, 56, 66), -7.41f, 4.64f);
        transform.position = playerPos; 

    }
}
