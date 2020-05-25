using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spear : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float SpeedSpear;
    public Rigidbody2D body;
    private bool dir;
    public int dammage = 15;
    public float Times;
    public float startTime;
   
    
    

    void Start()
    {
        
        Times = startTime;
        body.velocity = transform.right * SpeedSpear;
        
    }
    

    void OnTriggerEnter2D(Collider2D info)
    {
        Enemy enemy = info.GetComponent<Enemy>();
        Pyke pike = info.GetComponent<Pyke>();

        if (pike!= null)
        {
            Destroy(gameObject);
        }
        if (enemy!=null)
        {
            
            enemy.TakeDamage(dammage);
            
          //  Destroy(gameObject);
        }
        
        else
        {
            
            body.velocity = Vector2.zero;
            body.gravityScale = 0;
            body.tag = "IsGround";
            body.mass = 10000000000;
            dammage = 0;


        }
        
        
      
       
    }
}
