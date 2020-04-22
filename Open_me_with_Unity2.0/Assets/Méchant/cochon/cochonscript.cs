using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class cochonscript : MonoBehaviour
{
    // la vie du cochon
    private int hp = 2;
    
    private Vector2 velocity;
    
    // physique 2D du cochon
    private Rigidbody2D cochon;
    
    
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
        cochon = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (false)
        {
            Destroy(GameObject.Find(this.name));
        }

        velocity = Vector2.zero;
        position = cochon.transform.position;
        positionperso = GameObject.Find("character").transform.position;

        if (positionperso.x - 13 < position.x && positionperso.x + 13 > position.x)
        {
            if (positionperso.x - 1.8 < position.x && positionperso.x + 1.8 > position.x)
            {
                fastx = 0;
            }
            else if (positionperso.x < position.x)
            {
                fastx = -4;
                if (!retourner)
                {
                    cochon.transform.Rotate(rotat);
                    retourner = true;
                }
            }
            else
            {
                fastx = 4;
                if (retourner)
                {
                    cochon.transform.Rotate(rotat);
                    retourner = false;
                }
            }
        }

        //if (positionperso.y - 0.5 < position.y && positionperso.y + 0.5 > position.y)
        //{
        //    fasty = 0;
        //}
        //else if (positionperso.y < position.y)
        //{
        //    fasty = -1;
        //}
        //else
        //{
        //    fasty = 1;
        //}
        
        Vector3 move = new Vector3(fastx, cochon.velocity.y, 0);
        cochon.velocity = move;
        
    }

  

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        Debug.Log("damage TAKEN");
    }
    
    
    
    
}
