
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mars_bihavior : MonoBehaviour
{

    public bool isinvulnerable = true;
    public bool isattakcing = false;
    public float attacklength=200;
    public float vulnerability = 10f;
    public float TimeBefore = 70;
    private Rigidbody2D rb;
    private Transform player;
    private bool retourner = true;
    private bool canmele = true;
    public Enemy _enemy;
    public Animator animator;
    private Vector2 target;
    public float meleing = 0;
    

    public bool hasmele = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb=GetComponent<Rigidbody2D>();
        _enemy.isinvulnerable = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        target= new Vector2(player.position.x-rb.position.x, player.position.y-rb.position.y);
       if (target.x<0 && isinvulnerable)
       {
           if (!retourner)
           {
               rb.transform.Rotate(0,180,0);
               retourner = true;
           }
       }
       else
       {
           if (retourner)
           {
               rb.transform.Rotate(0,180,0);
               retourner = false;
           }
       }
        if (System.Math.Abs(target.x) < 2.5 && canmele && !isattakcing && meleing==0)
        {
            meleing = 120;
            animator.SetBool("mele",true);
            canmele = false;
            hasmele = false;
        }
        else if (meleing==0)
        {
            animator.SetBool("mele",false);
            TimeBefore -= 1;
            if (TimeBefore <= 0)
            {
                isattakcing = true;
                animator.SetBool("attack",true);
            }
        }
        
        if (isattakcing)
        { 
            canmele = true; 
            attack(target); 
            attacklength -= 1; 
            if (attacklength <= 0)
            {
                TimeBefore = 120;
                attacklength = 200;
                isattakcing = false;
                isinvulnerable = false;
                _enemy.isinvulnerable = false;
                rb.velocity=Vector2.zero;
                animator.SetBool("attack",false);
            }
        }

        if (meleing > 0)
        {
            mele(meleing);
            meleing--;
            if (meleing==0)
                animator.SetBool("mele",false);
        }
        if (!isinvulnerable)
        {
            animator.SetBool("killme",true);
            vulnerability -= 1;
            if (vulnerability <= 0)
            {
                animator.SetBool("killme",false);
                vulnerability = 60;
                isinvulnerable = true;
                _enemy.isinvulnerable = true;
            }
        }
        
    }

    public void attack(Vector2 target)
    {
        rb.velocity +=new Vector2(target.x/20,0);
        rb.transform.Rotate(0,180,0);
    }   
    
    public void mele(float countdown)
    {
        if (countdown < 60)
        {
            if (target.y < 0.8 &&((target.x >-3 && retourner)||(target.x <3 && !retourner)) && !hasmele)
            {
                hasmele = true;
                Debug.Log("ichi");
                player.GetComponent<playermoves>().TakeDamage(1);
                
            } 
        }
    }

    void OnDestroy()
    {
        if (!_enemy.IsAlive)
        {
            SceneManager.LoadScene("victory");
        }
        
    }
}
