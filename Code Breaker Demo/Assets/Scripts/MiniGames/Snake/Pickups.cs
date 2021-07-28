using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public static Pickups instance;
    public GameObject Food; 
    private float minZ = -19.16f, maxZ = -7.82f, minX = 36.42f, maxX = 25.28f;
    private float Ypos = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
       // Invoke("StartSpawning", 0.5f);
    }

    private void Start()
    {
        Invoke("StartSpawning", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeInstance()
    {   
        if(instance == null)
        {
            instance = this; 
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPickup());
    }

    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    IEnumerator SpawnPickup()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        Instantiate(Food, new Vector3 (Random.Range(minX, maxX), Ypos , Random.Range(minZ, maxZ)),Quaternion.identity);

        Invoke("StartSpawning", 0f);
    }
}
