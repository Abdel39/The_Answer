using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class playermoves : MonoBehaviour
{
    
    private Rigidbody2D body;
    public Transform isgrounded;
    public Transform cellingcheck;
    private bool isfacingright = true;
    private bool hasSpear = false;
    private bool isruning = false;
    private bool isGrounded = true;
    private bool isjumping = false;
    private float cayotyTime = 0;
    private bool candashagain = true;
    private PlayerMotor motor;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        
    }
    // Start is called before the first frame update
    void Update()
    {
        // prend la valeur des axe x et y
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        //prend la velocité
        Vector2 velocity = new Vector2( x , y);
        
        //aplique la vélocité à payermotor
        motor.RunAndJump(velocity);
        
       

    }

    // Update is called once per frame
    
}
