using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int xPos;
    public int zPos;
    public int enemyCount;
    int randEnemy;
    int Level; 


    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        StartCoroutine(Spawn());            
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Spawn()
    {
        while (Level == 1 && enemyCount >= 0  && enemyCount < 5)
        {
            randEnemy = Random.Range(0, 1);
            xPos = Random.Range(-30, 135);
            zPos = Random.Range(-30, 135);
            Instantiate(enemies[randEnemy], new Vector3(xPos, 10, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemyCount += 1;            
        }
    }
}
