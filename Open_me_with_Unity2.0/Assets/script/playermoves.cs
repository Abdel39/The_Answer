using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMotor))]
public class playermoves : MonoBehaviour
{
    public int lifePoint = 3;
    private int invincibility = 30;
    
    private Rigidbody2D body;

    
    private bool isruning = false;
    private bool isGrounded = true;
    public bool jumpmemory = false;
    public float jumpclock = 0;
    private PlayerMotor motor;
    private float x;
    private float y;
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
        

        

       
        if (Input.GetAxisRaw("Jump") > 0)
        {
            jumpclock = 0.2f;
        }
        else
        {
            jumpclock -= Time.deltaTime;
        }
        
        

        

       

        

        //prend la velocité
        Vector2 velocity = new Vector2(x, y);
    }

  

    private void FixedUpdate()
    {
       
        
            Vector2 velocity = new Vector2(x, y);
            //aplique la vélocité à payermotor
            motor.RunAndJump(velocity, jumpclock > 0);
           
                
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(1);
        }
        
        Pyke pike = other.collider.GetComponent<Pyke>();
        if (pike != null)
        {
            TakeDamage(3);
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

   
}