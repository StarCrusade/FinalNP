using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowPlayer : MonoBehaviour
{
    float speed = 20; //Make this 10 when you done lol
    Transform playerTransform;
    Vector3 target;

    GameObject player;
    ArenaPlayerHealth playerHealthScript;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        target = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<ArenaPlayerHealth>();
        transform.LookAt(playerTransform);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other )
    {
        if (other.tag == "MainCamera")
        {
            Damage();
            Destroy(gameObject);
        }
        else if (other.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(WaittoDestroy());
        }
    }
    void Damage()
    {
        playerHealthScript.currentHealth -= 10;
    }

    IEnumerator WaittoDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);        
    }
}
