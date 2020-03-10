using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.WSA;
public class cochonscript : MonoBehaviour
{
    // la vie du cochon
    private int life = 2;
    
    private Vector2 velocity;
    
    // physique 2D du cochon
    private Rigidbody2D cochon;
    
    
    public float fastx;
    public float fasty;
    
    public Vector3 position;
    public Vector3 positionperso;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        cochon = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(GameObject.Find("cochon"));
        }
        
        velocity = Vector2.zero;
        position = GameObject.Find("cochon").transform.position;
        positionperso = GameObject.Find("character").transform.position;
        
        if (positionperso.x - 1.8 < position.x && positionperso.x + 1.8 > position.x)
        {
            fastx = 0;
        }
        else if (positionperso.x < position.x)
        {
            fastx = -4;
        }
        else
        {
            fastx = 4;
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
        
        Vector3 move = new Vector3(fastx, fasty, 0);
        cochon.velocity = move;
    }

    public void TakeDamage(int damage)
    {
        life = life - damage;
        Debug.Log("damage TAKEN");
    }
    
    
    
    
}
