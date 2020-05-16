using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public Rigidbody2D rb;
    private Vector2 velocity;
    public float scrol;
    void Start()
    {


        rb.velocity = transform.right * scrol;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
