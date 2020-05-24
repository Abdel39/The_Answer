using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redashS : MonoBehaviour
{
    
    public PlayerMotor i;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        string n = other.tag;
        if (n == "player")
        {
            i.candash = true;
        }
        
    }
}
