using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public static String currentScene;
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;

    //public AudioSource audioSource;
    // Update is called once per frame
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
       
        //audioSource.volume = settingMenu.getVolume();
    }

    void Update()
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

    public void Restart()
    {
        
         SceneManager.LoadScene(currentScene);
            Resume();
        
    }

    

    public void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(false);
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
