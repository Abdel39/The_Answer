using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float SpeedSpear;
    public Rigidbody2D body;
    private bool dir;
    private int dammage = 5;
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
        if (enemy!=null)
        {
            enemy.TakeDamage(dammage);
          //  Destroy(gameObject);
        }
        else
        {
            body.velocity = Vector2.zero;
            
            
            Debug.Log("stylé");
            
        }
        Debug.Log(info);
        
      
       
    }
}
