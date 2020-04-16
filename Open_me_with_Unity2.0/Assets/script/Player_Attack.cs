using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    private float Time_Between_Attack;
    public float Start_Between_Attack;

     public Transform AttackPos;
     public float AttackRange;
    public LayerMask WhatIsEnemies;
    public int damage;
    public Animator animator;

  //  public Animator Animator;
    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame

    private void Update()
    {
        //if (Time_Between_Attack<=0)
        //    {
                //you can attack
                if (Input.GetButtonDown("Fire2"))
                {
                
                
               
               
                    animator.SetTrigger("Attack");
                    // Zone de dommage
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position,AttackRange,WhatIsEnemies);

                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        bool n = enemiesToDamage[i].GetComponent<Mars_bihavior>().isinvulnerable;
                        enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage, n);
                    }
                }
            
                Time_Between_Attack = Start_Between_Attack;
       //     }
        //    else
         //  {
            //   Time_Between_Attack = Time_Between_Attack - Time.deltaTime;
           // }
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.red;
              Gizmos.DrawWireSphere(AttackPos.position,AttackRange);
    }
}