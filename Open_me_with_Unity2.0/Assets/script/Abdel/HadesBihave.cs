﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class HadesBihave : MonoBehaviour
{
    public Enemy Enemy;
    public GameObject pball;
    public GameObject hand;
    public GameObject poseinstance;
    public GameObject poseidon;

    public int lifepoint;
    public int phase;
    public int clockmax;
    private int clock;
    private GameObject ActualP;
    private int clock2;
    public Rigidbody2D rb;
    public Rigidbody2D player;
    public CircleCollider2D shield;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        lifepoint = Enemy.hp;
        clock = clockmax*3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifepoint != Enemy.hp)
        {
            lifepoint = Enemy.hp;
            clock = clockmax*3;
            phase++;
            Heart();
            clock2 = 0;
            rb.velocity=Vector2.zero;
            if (phase == 7 || phase == 3)
            {
                poseinstance=Instantiate(poseidon);
            }
            else if (phase == 4 || phase == 9)
            {
                Destroy(poseinstance);
            }
            
        }

        else
        {
            switch (phase)
            {
                case 1:
                    Taurus();
                    break;
                case 2:
                    Hand();
                    break;
                case 3:
                    break;
                case 4 :
                    Spawner();
                    break;
                case 5:
                    Taurus();
                    Spawner();
                    break;
                case 6:
                    Hand();
                    Spawner();
                    break;
                case 7:
                    Stomp();
                    break;
                case 8:
                    Taurus();
                    break;
                case 9:
                    Enemy.hp = 1;
                    break;
            }

            clock2--;
            if (clock == 0)
            {
                Pswitch();
            }

            clock--;
            
        }
    }

    private void Taurus()
    {
        if (clock2 <= 0)
        {
            clock2 = 500;
            rb.velocity=Vector2.zero;
        }
        else if (clock2 < 450)
        {
            rb.velocity += new Vector2((player.position.x - rb.position.x)/15, -1);
        }

        if (clock2 == 200 || clock2 == 300)
        {
            rb.velocity=Vector2.up*25;
        }
        
        
    }

    private void Hand()
    {
        
    }

    private void Spawner()
    {
        
    }

    private void Stomp()
    {
        
    }

    private void Pswitch()
    {
        Destroy(ActualP);
        Vector3 vect= new Vector2(Random.Range(31,65),Random.Range(-10,2.5f));
        ActualP = Instantiate(pball, vect,Quaternion.identity);
        clock = clockmax;
    }
    
    private void Heart()
    {
        Vector3 vect= new Vector2(Random.Range(31,65),Random.Range(-10,2.5f));
        Instantiate(heart, vect,Quaternion.identity);
        clock = clockmax;
    }
}
