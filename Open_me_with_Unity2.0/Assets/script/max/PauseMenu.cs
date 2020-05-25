using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public static String currentScene="empty";
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;
    public bool fromGameOver = false;

    //public AudioSource audioSource;
    // Update is called once per frame
    private void Start()
    {
        if (! fromGameOver)
        {
            currentScene = SceneManager.GetActiveScene().name;
        }
        else
        {
            if (currentScene == "empty")//juste au cas ou
            {
                currentScene = "First level"; 
            }
            // si je suis dans la scene gameover je veux que restart relance l avant dernier scene ( pas game over)
        }
       
       
        //audioSource.volume = settingMenu.getVolume();
    }

    void Update()
    {
        if (!fromGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
       
    }

    public void Restart()
    {
        
         SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;

    }

    

    public void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() 
    {
        if (pauseMenuUI != null && optionMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            optionMenuUI.SetActive(false);
        }
       
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Debug.Log("je click sur loadMainScene");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
