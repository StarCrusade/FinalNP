using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public GameObject robotContainer;
    public GameObject robotContainer2;
    public GameObject robotContainer3;
    public GameObject robotContainer4;

    private RobotScript[] robot;
    private RobotScript2[] robot2;
    private RobotScript3[] robot3;
    private RobotScript4[] robot4;
    public float showmoletimer = 4f;
    public float showmoletimer2 =6f;
    public float showmoletimer3 = 8f;
    public float showmoletimer4 = 10f;


    // Start is called before the first frame update
    void Start()
    {
        robot = robotContainer.GetComponentsInChildren<RobotScript>();
        robot2 = robotContainer2.GetComponentsInChildren<RobotScript2>();
        robot3 = robotContainer3.GetComponentsInChildren<RobotScript3>();
        robot4 = robotContainer4.GetComponentsInChildren<RobotScript4>();
    }

    // Update is called once per frame
    void Update()
    {
        showmoletimer -= Time.deltaTime;
        showmoletimer2 -= Time.deltaTime;
        showmoletimer3 -= Time.deltaTime;
        showmoletimer4 -= Time.deltaTime;

        if (showmoletimer < 0f || showmoletimer2 < 0f || showmoletimer3 < 0f || showmoletimer4 < 0f)
        {
            robot[Random.Range(0, robot.Length)].Show();           
            showmoletimer = 4f;
            
        }
        if (showmoletimer2 < 0f)
        {            
            robot2[Random.Range(0, robot2.Length)].Show();
            showmoletimer2 = 6f;
        }
        if (showmoletimer3 < 0f)
        {
            robot3[Random.Range(0, robot3.Length)].Show();
            showmoletimer3 = 8f;
        }
        if (showmoletimer4 < 0f)
        {           
            robot4[Random.Range(0, robot4.Length)].Show();
            showmoletimer4 = 10f;
        }

    }
}
