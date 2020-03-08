using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class playermoves : MonoBehaviour
{
    
    private Rigidbody2D body;
    private bool isfacingright = true;
    private bool hasSpear = false;
    private bool isruning = false;
    private bool isGrounded = true;
    public bool jumpmemory = false;
    public float jumpclock = 0;
    private float dash = 0;
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
        
        // clocks du saut et du dash
        if (jumpmemory)
        {
	        jumpclock -= Time.deltaTime;
        }
        else
        {
	        jumpclock = 0f;
        }
        if (jumpclock > 0)
        {
	        jumpmemory =false;
        }
        dash-= Time.deltaTime;
	    if (Input.GetButtonDown("Jump"))
	    {
		    jumpmemory = true;
		    jumpclock = 0.2f;
	    }
	    if (Input.GetButtonUp("dash"))
	    {
		    dash = 0.2f;
	    }
        //prend la velocité
        Vector2 velocity = new Vector2( x , y);
        
        //aplique la vélocité à payermotor
        motor.RunAndJump(velocity,jumpmemory,dash);
        
       

    }

    // Update is called once per frame
    
}
