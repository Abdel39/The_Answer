using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchEditedLvl()
    {
        SceneManager.LoadScene("EditedLvl");
    }
    public void launchFirstLvl()
    {
        SceneManager.LoadScene("First level");
    }
    
    public void launchSecondLvl()
    {
        SceneManager.LoadScene("Second level");
    }
    
    public void backButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void launchMars()
    {
        SceneManager.LoadScene("Mars boss Battle");
    }
    public void launchHades()
    {
        SceneManager.LoadScene("Hades boss battle");
    }
    public void launchSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void launchVictory()
    {
        SceneManager.LoadScene("victory");
    }

}
