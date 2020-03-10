using System.Collections;
using System.Collections.Generic;
using script;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.WSA;
public class cochonscript : MonoBehaviour
{
   
    // la vie du cochon
    public static int life=2 ;
    public static int damage=2 ;

    
    Cochon myCochon = new Cochon(life, damage);
    
    private Vector2 velocity;
    
    // physique 2D du cochon
    private Rigidbody2D cochon;
    
    
    private float fastx;
    private float fasty;
    
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
        
       
        Vector3 move = new Vector3(fastx, fasty, 0);
        cochon.velocity = move;
    }

    public void TakeDamage(int damage)
    {
        myCochon.takeDamage(damage);
    }

    public void attack(Entity entity)
    {
        entity.takeDamage(myCochon.damage);
    }
    
    
    
    
}
