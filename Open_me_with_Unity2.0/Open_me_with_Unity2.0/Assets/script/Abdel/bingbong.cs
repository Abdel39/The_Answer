using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class bingbong : MonoBehaviour
{
    public Object obj;

    public Collider2D box;

    public Enemy Enemy;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity=new Vector2(-20,0);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy.IsAlive = false;
    }
}
