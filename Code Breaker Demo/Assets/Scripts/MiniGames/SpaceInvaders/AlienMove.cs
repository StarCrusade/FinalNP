using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MonoBehaviour
{
    public float speed = 20;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(2.5f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            rb.velocity = new Vector3(-2.5f, 0, 0);
            MoveDown();
        }
        else if (other.tag == "LWall")
        {
            rb.velocity = new Vector3(2.5f, 0, 0);
            MoveDown();
        }
        else if (other.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }

    void MoveDown()
    {
        Vector3 position = transform.position;
        position.z -= 0.5f;
        transform.position = position;
    }
}
