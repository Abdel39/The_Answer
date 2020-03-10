﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMotor))]
public class playermoves : MonoBehaviour
{
    private int lifePoint = 3;
    private int invincibility = 30;
    
    private Rigidbody2D body;
    public bool isfacingright = true;
    private bool hasSpear = false;
    private bool isruning = false;
    private bool isGrounded = true;
    public bool jumpmemory = false;
    public float jumpclock = 0;
    private float dash = 0;
    private PlayerMotor motor;
    private float x;
    private float y;
    private float Time_Between_Attack;
    public float Start_Between_Attack;
    public Transform AttackPos;
    public Transform AttackPosL;
    public float AttackRange;
    public LayerMask WhatIsEnemies;
    public int damage;
    public bool isattaking;
    public float attacktime;
    public float attacktimed;
    public Animator Animator;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Start is called before the first frame update
    void Update()
    {
        invincibility--;

        // prend la valeur des axe x et y
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (x > 0)
        {
            isfacingright = true;
            Animator.SetBool("is facing right", true);
        }
        else if (x < 0)
        {
            isfacingright = false;
            Animator.SetBool("is facing right", false);
        }

        dash -= Time.deltaTime;
        if (Input.GetAxisRaw("Jump") > 0)
        {
            jumpclock = 0.2f;
        }
        else
        {
            jumpclock -= Time.deltaTime;
        }

        if (Input.GetButtonUp("dash"))
        {
            dash = 0.2f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isattaking = true;
            attacktimed = attacktime;
            Animator.SetBool("is attacking", true);
        }

        if (attacktimed > 0)
        {
            attacktimed -= Time.deltaTime;
        }
        else
        {
            isattaking = false;

            Animator.SetBool("is attacking", false);
        }

        //prend la velocité
        Vector2 velocity = new Vector2(x, y);
    }

    public void Attack()
    {
        if (Time_Between_Attack <= 0)
        {
            //you can attack


            // Annimation
            // Animator.SetTrigger("Attack");


            // Zone de dommage
            if (isfacingright)
            {
                Collider2D[] enemiesToDamage =
                    Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            else
            {
                Collider2D[] enemiesToDamage =
                    Physics2D.OverlapCircleAll(AttackPosL.position, AttackRange, WhatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }


            Time_Between_Attack = Start_Between_Attack;
        }
        else
        {
            Time_Between_Attack = Time_Between_Attack - Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isattaking)
        {
            Attack();
        }
        else
        {
            Vector2 velocity = new Vector2(x, y);
            //aplique la vélocité à payermotor
            motor.RunAndJump(velocity, jumpclock > 0, dash);
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibility < 0)
        {
            lifePoint -= damage;
            if (lifePoint <= 0)
            {
                lifePoint = 0;
                die();
            }

            showLife();
            invincibility = 30;
        }
    }

    public void showLife()
    {
        LifeImage.UpdateHeartImage(lifePoint);
    }

    public void die()
    {
        SceneManager.LoadScene("GameOver");
        
    }

    // Update is called once per frame
}