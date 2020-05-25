using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerBeforeGravity : MonoBehaviour
{
    public int timer;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            rb.gravityScale = 5;
            Destroy(this);
        }
        else
        {
            timer--;
        }
    }
}
