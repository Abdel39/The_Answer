﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    private GameObject character;

    private bool test = false;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "IsGround")
        {
            character.GetComponent<PlayerMotor>().isgrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "IsGround")
        {
            test = true;
            character.GetComponent<PlayerMotor>().isgrounded = true;
        }
    }

    
}
