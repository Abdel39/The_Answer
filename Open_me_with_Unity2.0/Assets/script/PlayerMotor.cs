using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof( playermoves))]



// Ici on gère la physique du personnage dans les déplacement
public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 velocity;
    private bool input_jump;
    private bool input_dash;
    
    // physique 2D du personnage
    private Rigidbody2D rb;
    
    //vitesse max
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpstrenght;
    [SerializeField] private float dashstrength;
    public bool isgrounded=false;
    public Transform cellingcheck;
    private float cayotyTime = 0;
    public bool candashagain = true;
    public float fallingspeed = 1.1f;
    
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
                cayotyTime = 0.1f;
                candashagain = true;
            }
            else
            {
                cayotyTime -= Time.deltaTime;
            }
            PerformRunAndJump();
        
    }

    public void RunAndJump(Vector2 _velocity,bool jumpmemory,float dash)
    {
        velocity = _velocity;
        input_jump = jumpmemory && cayotyTime > 0;
        input_dash = dash > 0;
    }

    private void PerformRunAndJump()
    {
        if (input_dash)
        {
            if (candashagain)
            {
                rb.velocity= new Vector2(0,0);
                rb.AddForce(new Vector2(velocity.x*dashstrength,velocity.y*dashstrength));
                candashagain = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime , rb.velocity.y);
            if (input_jump)
            {
                rb.AddForce(new Vector2(0,jumpstrenght));
                cayotyTime = 0;
            }
            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0,rb.velocity.y*fallingspeed));
            }
        }
    }
        
}
