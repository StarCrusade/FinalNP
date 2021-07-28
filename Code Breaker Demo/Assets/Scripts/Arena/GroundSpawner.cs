using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GroundSpawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] enemies;
    public GameObject Grenade;
    public GameObject gPosition;
    public int killCount = 0; 
    public int spawnAmount = 0;
    public int enemiesKilled = 0;
    int randEnemy;
    int spawnerID;
    int waveNum = 0;

    bool GrenadeSpawn = false;


    private void Start()
    {
        spawners = new GameObject[110];

        for(int i =0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    private void Update()
    {
        if (enemiesKilled >= spawnAmount)
        {
            NextWave();
        }

        if (killCount == 15 && !GrenadeSpawn)
        {
            GrenadeSpawn = true;
            GameObject grenade = Instantiate(Grenade, gPosition.transform.position, Quaternion.identity) as GameObject;
            killCount = 0;
                       
        }
        else
        {            
            GrenadeSpawn = false;
        }
        

        if(killCount == 20)
        {
            // Spawn boss here 
        }

    }   

    void Spawn()
    {       
        randEnemy = Random.Range(0, 1);
        spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemies[randEnemy], spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation); 
    }

    void StartWave()
    {
        waveNum = 1;
        spawnAmount = 5;
        enemiesKilled = 0; 

        for(int i= 0; i < spawnAmount; i++)
        {
            Spawn();
        }
    }

    public void NextWave()
    {
        enemiesKilled = 0;
        waveNum++;
        spawnAmount += 5;

        for (int i = 0; i < spawnAmount; i++)
        {
            Spawn();
        }

    }
   
}
