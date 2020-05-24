using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string n = collision.tag;
        if (n == "Ennemies")
        {
            collision.GetComponent<Enemy>().TakeDamage(1,false);
        }

        if (n == "IsGround")
        {
            Destroy(this.gameObject);
        }
        
    }
}
