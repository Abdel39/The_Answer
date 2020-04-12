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

    private bool Istouch = false;
    // Update is called once per frame
    public bool HaveSpear;
    public float Times ;
    void Update()
    {

       
        
    
        

        // avoir la lance et presser le bouton
        if (HaveSpear && Input.GetButtonDown("Fire3"))
        {
         // tirer
        Spears();
        HaveSpear = false;

        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            
            
            Times = 1;
        }

        
        if (Times>0)
        {
            Times = Times - Time.deltaTime;
            Istouch = true;
        }
        else
        {
            Istouch = false;
        }


    }

    


    void OnTriggerEnter2D(Collider2D info)
    {
        Spear spear = info.GetComponent<Spear>();
        if (spear!=null)
        {
            Destroy(info.gameObject);
            HaveSpear = true;
        }
        
        Debug.Log(info);
        
      
       
    }


    void Spears()
    {
        Instantiate(SpearSpawn, FirePoint.position, FirePoint.rotation);
    }
}
