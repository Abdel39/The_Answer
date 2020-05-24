using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class changerLesTouches : MonoBehaviour
{
    public Button leftButton;
    public Text leftText;
    public Button rightButton;
    public Text rightText;
    public Button upButton;
    public Text upText;
    public Button fistButton;
    public Text fistText;
    public Button lanceButton;
    public Text lanceText;

    private bool waitingForKey=false;
    // Start is called before the first frame update
    void Start()
    {
        
        /*KeyCode current = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumPrefs"));
        Debug.Log("current jump : "+current);*/
        
        //PlayerPrefs.SetString("jumpPrefs","m");
        /*current = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumPrefs"));
        */
        /*
        Debug.Log("current RIGHT : "+PlayerPrefs.GetString("right"));
          Debug.Log("current left : "+PlayerPrefs.GetString("left"));
          Debug.Log("current jump : "+PlayerPrefs.GetString("jump"));
*/

          // 

    }
    
    private void Update()
    {
        /*if (waitingForKey)
        {
            Event keyEvent = Event.current;
            if (keyEvent.isKey)
            {
               KeyCode neyKey = keyEvent.keyCode;
               
            }
        }*/
    }

    public void leftButtonClicked()
    {
        waitingForKey = true;
        //leftText.text = "";
    }
    public void rightButtonClicked()
    {
        waitingForKey = true;
        //rightText.text = "";
    }
    public void upButtonClicked()
    {
        waitingForKey = true;
        //upText.text = "";
    }
    public void fistButtonClicked()
    {
        waitingForKey = true;
        //fistText.text = "";
    }
    public void lanceButtonClicked()
    {
        waitingForKey = true;
        //lanceText.text = "";
        
    }
}
