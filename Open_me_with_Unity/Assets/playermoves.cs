using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermoves : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody2D body;
    public Transform isgrounded;
    public Transform cellingcheck;
    private bool isfacingright = true;
    private bool hasSpear = false;
    private bool isruning = false;
    private bool isGrounded = true;
    private bool isjumping = false;
    private float x = 0;
    private float y = 0;
    private float cayotyTime = 0;
    private bool candashagain = true;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2 (x * speed, body.velocity.y);
    }
}
