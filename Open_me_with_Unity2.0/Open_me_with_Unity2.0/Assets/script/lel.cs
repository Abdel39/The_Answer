using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lel : MonoBehaviour
{
    
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.position = GameObject.Find("character").transform.position;
    }
}
