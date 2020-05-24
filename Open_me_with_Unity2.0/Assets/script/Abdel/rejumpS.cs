using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rejumpS : MonoBehaviour
{
    public PlayerMotor i;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        string n = other.tag;
        if (n == "player")
        {
            i.isjumping = true;
            i.cayotyTime = 0.2f;
        }
        
    }
}
