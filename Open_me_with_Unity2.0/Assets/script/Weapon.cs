using System;
using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

  

    // Start is called before the first frame update
    public Transform FirePoint;

    public GameObject SpearSpawn;
    
    public bool Istouch = false;
    private Collider2D test;
    public bool HaveSpear;
    public Animator _animator;
    void Update()
    {
        // avoir la lance et presser le bouton
        if (HaveSpear && Input.GetButtonDown("Fire3"))
        {
         // tirer
         HaveSpear = false;
        Spears();
        

        }

        _animator.SetBool("HaveSpear",HaveSpear);

        if (test != null)
        {
            if (Input.GetKeyDown(KeyCode.R) && Istouch)
            {
                Destroy(test.gameObject);
                HaveSpear = true; 
            }
        }
    }

    


    void OnTriggerEnter2D(Collider2D info)
    {
        Spear spear = info.GetComponent<Spear>();
        if (spear!=null)
        {
            Istouch = true;
            test = info;
            
        }
    }


    void Spears()
    {
        Instantiate(SpearSpawn, FirePoint.position, FirePoint.rotation);
    }
}
    