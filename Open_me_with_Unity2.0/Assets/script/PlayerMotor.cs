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
    private bool input_dash;
    public float jumpTime=(float)0.8;
    private float jumptimecounter;
    // physique 2D du personnage
    private Rigidbody2D rb;
    
    //vitesse max
    [SerializeField] private float maxSpeed=500;
    [SerializeField] private float Speed=300;
    [SerializeField] private float jumpstrenght=20;
    [SerializeField] private float dashstrength;
    public bool isgrounded=false;
    public float cayotyTime = 0;
    public bool candashagain = true;
    public float fallingspeed = 1.1f;
    public float jumpingTime;
    public bool isjumping;
    
    public bool isfacingright = true;
    public Animator animator;
    
    void Start()
    {
        velocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (isgrounded)
            {
                cayotyTime = 0.2f;
                candashagain = true;
            }
            else
            {
                cayotyTime -= Time.deltaTime;
            }

            PerformRunAndJump();
          
            if (input_dash)
            {
                Dash();
            }
            
           
            
    }
    
    private void Flip()
    {
        isfacingright = !isfacingright;
        transform.Rotate(0f, 180f, 0f);
       

    }
    
    
    
    
    

    public void RunAndJump(Vector2 _velocity,bool jumpmemory,float dash)
    {
        velocity = _velocity;
        input_jump = jumpmemory;
        input_dash = dash > 0;
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
            animator.SetBool("run",false);
        }
        else
        {
            animator.SetBool("run",true);
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

    private void Dash()
    {
        if (candashagain)
        {
            rb.velocity= new Vector2(0,0);
            rb.AddForce(new Vector2(velocity.x*dashstrength,velocity.y*dashstrength));
            candashagain = false;
        }
    }


}
