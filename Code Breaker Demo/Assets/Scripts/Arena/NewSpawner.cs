﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSpawner : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject bossEnemy;
    //public Text EnemiesAliveText;
  //  public Text WaveNumberText;

    public int EnemiesToSpawn;
    private int currentEnemies;
    public static int enemiesKilled;
    private float spawnRangeX;
    private float spawnRangeZ;
    public float setMaxSpawnRangeX;
    public float setMaxSpawnRangeZ;
    private float intervalToSpawn;
    public float nextSpawnTimer;

    [HideInInspector]
    public float waveNumber;
    public float maxWaves;
    private float intervalToWave;
    public float nextWaveTimer;
    private bool changedWave = false;
    private bool spawnedBoss = false;
    public static bool killedBoss = false;


    void Start()
    {
        waveNumber = 1;
        intervalToWave = nextWaveTimer;
        intervalToSpawn = nextSpawnTimer;
        spawnRangeX = Random.Range(-50, 50);
        spawnRangeZ = Random.Range(-50, 50);
    }

    void Update()
    {
        intervalToSpawn -= Time.deltaTime;

        if (intervalToSpawn <= 0 && currentEnemies < EnemiesToSpawn && waveNumber < maxWaves + 1)
        {
            Instantiate(normalEnemy, new Vector3(transform.position.x + spawnRangeX, transform.position.y, transform.position.z + spawnRangeZ), transform.rotation);
            spawnRangeX = Random.Range(-setMaxSpawnRangeX, setMaxSpawnRangeX);
            spawnRangeZ = Random.Range(-setMaxSpawnRangeZ, setMaxSpawnRangeZ);

            while (spawnRangeX <= 60 && spawnRangeX >= -60 && spawnRangeZ <= 60 && spawnRangeZ >= -60)
            {
                spawnRangeX = Random.Range(-setMaxSpawnRangeX, setMaxSpawnRangeX);
                spawnRangeZ = Random.Range(-setMaxSpawnRangeZ, setMaxSpawnRangeZ);
            }

            intervalToSpawn = nextSpawnTimer;
            currentEnemies++;
        }

        if (enemiesKilled == EnemiesToSpawn)
        {
            if (spawnedBoss == false)
            {
                Instantiate(bossEnemy, new Vector3(transform.position.x + spawnRangeX, transform.position.y, transform.position.z + spawnRangeZ), transform.rotation);
                spawnedBoss = true;
            }
            if (changedWave == false && killedBoss == true)
            {
                waveNumber++;
                changedWave = true;
            }
            if (killedBoss == true)
            {
                intervalToWave -= Time.deltaTime;
            }

            if (intervalToWave <= 0 && killedBoss == true)
            {
                EnemiesToSpawn = EnemiesToSpawn + 3;
                intervalToWave = nextWaveTimer;
                //intervalToSpawn = nextSpawn;
                changedWave = false;
                currentEnemies = 0;
                enemiesKilled = 0;
                spawnedBoss = false;
                killedBoss = false;
            }
        }

        // EnemiesAliveText.text = "EnemiesAlive: " + (currentEnemies - enemiesKilled).ToString();
        // WaveNumberText.text = "Wave: " + waveNumber;
    }
}
