using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public playermoves i;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        string n = other.tag;
        if (n == "player")
        {
            i = other.gameObject.GetComponent<playermoves>();
            if (i.lifePoint < 3)
            {
                i.TakeDamage(-1);
                Destroy(gameObject);
            }
        }
        
    }
}
