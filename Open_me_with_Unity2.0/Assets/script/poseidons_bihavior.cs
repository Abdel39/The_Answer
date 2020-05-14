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
                rb.velocity=Vector2.zero;
            }
        }
    }

    public void Attack()
    {
        if (attacklen < 100)
        {
            Lazor();
            if (attacklen == 0)
            {
                isattacking = false;
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
        Debug.Log("LAZOR");
    }
}
