using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof( playermoves))]



// Ici on gère la physique du personnage dans les déplacement
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 velocity;
    
    // physique 2D du personnage
    private Rigidbody2D rb;
    
    //vitesse max
    [SerializeField] private float maxSpeed;
    
    //vitesse reel
    [SerializeField] private float Speed;
    
    
    void Start()
    {
        velocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformRunAndJump();
    }

    public void RunAndJump(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void PerformRunAndJump()
    {
        if (Speed<maxSpeed)
        {
            
            rb.velocity = new Vector2(velocity.x * Speed * Time.deltaTime , rb.velocity.y);
            Speed = Speed + 3;
            
        }
        else
        {
            rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime , rb.velocity.y);
        }
        if (velocity.x==0)
        {
            Speed = 250;
        }
     
    }
}
