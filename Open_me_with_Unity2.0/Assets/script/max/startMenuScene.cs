using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    public void launchMenuScene()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("fjhbj");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
