using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_knockback : MonoBehaviour
{
    public Rigidbody2D player;

    private void Start()
    {
        player = GameObject.Find("character").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "player")
        {
            player.velocity += Vector2.up*20;
        }
    }

}
