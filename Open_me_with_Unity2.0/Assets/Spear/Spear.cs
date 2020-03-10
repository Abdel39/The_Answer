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





    void Start()
    {
      
        body.velocity = transform.right * SpeedSpear;
    }



    void OnTriggerEnter2D(Collider2D info)
    {
        Enemy enemy = info.GetComponent<Enemy>();
        if (enemy!=null)
        {
            enemy.TakeDamage(dammage);
        }
        Debug.Log(info);
        Destroy(gameObject);
    }
}
