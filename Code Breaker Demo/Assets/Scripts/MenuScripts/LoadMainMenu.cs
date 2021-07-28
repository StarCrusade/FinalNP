using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Time.timeScale == 0.0f)
            Time.timeScale = 1.0f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
