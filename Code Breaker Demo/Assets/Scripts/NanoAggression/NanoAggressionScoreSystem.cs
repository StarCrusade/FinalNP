using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NanoAggressionScoreSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject timerText;
    public GameObject gameOverText; 
    public static int theScore;
    float currentTime = 0;
    float startTime = 60;       

    private void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        scoreText.GetComponent<Text>().text = "Score: " + theScore;
        timerText.GetComponent<Text>().text = "Time Left: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            Time.timeScale = 0.01f;
            gameOverText.GetComponent<Text>().text = "Game Over ";
            StartCoroutine(GOwait());
        }

    }


    IEnumerator GOwait()
    {       
        yield return new WaitForSeconds(0.09f);       
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Tutorial");  
    }

  



 
}
    
