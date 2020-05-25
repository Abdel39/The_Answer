using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respearS : MonoBehaviour
{
    public Weapon i;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        string n = other.tag;
        if (n == "player")
        {
            i.HaveSpear = true;
        }
        
    }
}
