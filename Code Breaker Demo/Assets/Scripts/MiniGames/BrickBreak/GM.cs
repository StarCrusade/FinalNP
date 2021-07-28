using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class GM : MonoBehaviour
{
    public int lives = 3; 
    public int bricks = 40;
    public float resetDelay = 1;
    public GameObject BricksPrefab;
    public GameObject GameOver;
    public GameObject YouWon;
    public GameObject Paddle; 
    public Text livesText;
   // public Text ScoreText; 
    public static GM instance = null;
    private GameObject clonePaddle; 

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

       Setup();
       livesText.text = "Lives: " + lives;
    }

    void Setup()
    {
        clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(BricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if(bricks < 1)
        {
            YouWon.SetActive(true);
           
        }
        if(lives < 1)
        {
            GameOver.SetActive(true);
        }
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        // Instanciate death particles here if you want
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

   void SetupPaddle()
    {
        clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver(); 
    }

    IEnumerator SpawnMore()
    {
        yield return new WaitForSeconds(10);
        Instantiate(BricksPrefab, transform.position, Quaternion.identity);
    }

}
