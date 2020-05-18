using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon_balls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=new Vector2(-1,1)*speed;
    }
    
}
