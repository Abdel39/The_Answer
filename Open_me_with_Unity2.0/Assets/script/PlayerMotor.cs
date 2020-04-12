using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof( playermoves))]



// Ici on gère la physique du personnage dans les déplacement
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 velocity;
    public bool input_jump;
    
    public float jumpTime;
    private float jumptimecounter;
    // physique 2D du personnage
    private Rigidbody2D rb;
    
    
    
    //pour dash
    private int direction;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float moveInput;
    
    
    //vitesse max
    [SerializeField] private float maxSpeed;
    [SerializeField] private float Speed;
    [SerializeField] private float jumpstrenght;
    public bool isgrounded=false;
    public float cayotyTime = 0;
    
    public float fallingspeed = 1.1f;
    public float jumpingTime;
    public bool isjumping;
    public bool isfacingright = true;
    
    void Start()
    {
        velocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        
        dashTime = startDashTime;

    }

    private void Update()
    {
        Dash();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (isgrounded)
            {
                cayotyTime = 0.2f;
                
            }
            else
            {
                cayotyTime -= Time.deltaTime;
            }

            PerformRunAndJump();
          
           
            
           
            
    }
    
    private void Flip()
    {
        isfacingright = !isfacingright;
        transform.Rotate(0f, 180f, 0f);
       

    }


    private void Dash()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (moveInput< 0)
                {
                    direction = 1;
                    Debug.Log("dir =1" );
                }
                else if (moveInput > 0)
                {
                    direction = 2;
                    Debug.Log("dir =2" );
                }
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rb.AddForce(Vector2.left * dashSpeed);
                    
                }
                else if (direction == 2)
                {
                    
                    rb.AddForce(Vector2.right * dashSpeed);
                }
            }
        }
    }





    public void RunAndJump(Vector2 _velocity,bool jumpmemory)
    {
        velocity = _velocity;
        input_jump = jumpmemory;
        
        if (input_jump && (isgrounded||cayotyTime>0))
        {
            isjumping = true;
            jumptimecounter = jumpTime;
        }
    }

    public void PerformRunAndJump()
    {
        if (input_jump && isjumping && jumptimecounter > 0)
        {
            jumptimecounter -= Time.deltaTime;
            rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime,
                jumpstrenght * jumptimecounter / (jumpTime));
            cayotyTime = 0;
        }
        else
        {
            if (Speed>maxSpeed)
            {
                rb.velocity = new Vector2(velocity.x * maxSpeed * Time.fixedDeltaTime, rb.velocity.y);
                            isjumping = false;
            }
            else
            {
                rb.velocity = new Vector2(velocity.x * Speed * Time.fixedDeltaTime, rb.velocity.y);
                isjumping = false;

                Speed = Speed + 100;
            }
        }

        if (velocity.x == 0)
        {
            Speed = 0;
        }

        
        
        
        if (rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(0, rb.velocity.y * fallingspeed));
        }
        
        if (velocity.y < 0) rb.AddForce(new Vector2(0, -fallingspeed * 50));
        
        
        
        if ( velocity.x > 0 && !isfacingright)
        {
         
            Flip();
        }
        
        else if ( velocity.x < 0 && isfacingright)
        {
           
            Flip();
        }
        
        

}

    


}
