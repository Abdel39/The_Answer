using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class poseidons_bihavior : MonoBehaviour
{
    private bool isattacking;
    public int attlen;
    private int attacklen;
    public int cool;
    private int cooldown;
    private Rigidbody2D rb;
    private Transform player;

    public Animator Animator;
    public deplacement Deplacement;

    private int lazer = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb=GetComponent<Rigidbody2D>();
        cooldown = cool;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isattacking)
        {
            Attack();
        }
        else
        {
            cooldown--;
            Move();
            if (cooldown == 0)
            {
                cooldown = cool;
                attacklen = attlen;
                isattacking = true;
                Animator.SetTrigger("ATT");
                rb.velocity=Vector2.zero;
                lazer--;
                if (lazer == 0)
                {
                    Deplacement.scrol = 0;
                }
            }
        }
    }

    public void Attack()
    {
        if (attacklen < 100)
        {
            Lazor();
            if (attacklen == 99)
            {
                Animator.SetTrigger("LAZ");
            }
            if (attacklen == 0)
            {
                isattacking = false;
                Animator.SetTrigger("END");
            }
        }

        attacklen--;
    }

    public void Move()
    {
        float y = player.position.y - rb.position.y-0.5f;
        rb.velocity =new Vector2(0,10*y/10);
    }
        

    public void Lazor()
    {
        float p = player.position.y - rb.position.y;
        if (p>-0.125 && p<0.320)
            player.GetComponent<playermoves>().TakeDamage(1);
    }
}
