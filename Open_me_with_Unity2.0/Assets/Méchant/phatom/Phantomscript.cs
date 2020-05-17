using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Phantomscript : MonoBehaviour
{
    // la vie du phantom
    private int hp = 2;
    
    private Vector2 velocity;
    
    // physique 2D du phantom
    private Rigidbody2D phantom;
    
    
    private float fastx;
    private float fasty;

    private Vector3 rotat = new Vector3(0, 180,0);
    private bool retourner = true;
    
    private Vector3 position;
    private Vector3 positionperso;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        phantom = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hp <= 0)
        {
            Destroy(GameObject.Find(this.name));
        }

        velocity = Vector2.zero;
        position = phantom.transform.position;
        positionperso = GameObject.Find("character").transform.position;

        if (positionperso.x - 13 < position.x && positionperso.x + 13 > position.x)
        {
            if (positionperso.x - 1.2 < position.x && positionperso.x + 1.2 > position.x)
            {
                fastx = 0;
            }
            else if (positionperso.x < position.x)
            {
                fastx = -7;
                if (!retourner)
                {
                    phantom.transform.Rotate(rotat);
                    retourner = true;
                }
            }
            else
            {
                fastx = 7;
                if (retourner)
                {
                    phantom.transform.Rotate(rotat);
                    retourner = false;
                }
            }

            if (positionperso.y - 0.5 < position.y && positionperso.y + 0.5 > position.y)
            {
                fasty = 0;
            }
            else if (positionperso.y < position.y)
            {
                fasty = -4;
            }
            else
            {
                fasty = 4;
            }

            Vector3 move = new Vector3(fastx, fasty, 0);
            phantom.velocity = move;
        }
        else
        {
            Vector3 move = new Vector3(0, 0, 0);
            phantom.velocity = move;
        }
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage; 
        Debug.Log("damage TAKEN");
    }

}