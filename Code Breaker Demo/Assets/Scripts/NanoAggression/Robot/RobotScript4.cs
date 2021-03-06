using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript4 : MonoBehaviour
{
    public float visible = -3.49f;
    public float hidden = -5.12f;
    private Vector3 newXYZposition;
    public float speed = 4;
    public float hidetimer = 1f;
    public GameObject fireBall;
    public Transform mouth;

    private void Awake()
    {
        Hide();
        transform.localPosition = newXYZposition;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, newXYZposition, Time.deltaTime * speed);

        hidetimer -= Time.deltaTime;

        if (hidetimer < 0)
        {
            Hide();
        }
    }

    public void Hide()
    {
        newXYZposition = new Vector3(hidden, transform.localPosition.y, transform.localPosition.z);
    }
    public void Show()
    {
        newXYZposition = new Vector3(visible, transform.localPosition.y, transform.localPosition.z);
        hidetimer = 1f;        
        GameObject bullet = Instantiate(fireBall, mouth.position, Quaternion.identity);
        bullet.GetComponent<FollowPlayer>().ThisEnemy = gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireball")
        {            
            Destroy(other.gameObject);
            Hide();
        }
    }
}
