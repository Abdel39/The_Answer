using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public playermoves i;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        string n = other.collider.tag;
        if (n == "player")
        {
            if (i.lifePoint < 3)
            {
                i.TakeDamage(-1);
                Destroy(gameObject);
            }
        }
    }
}
