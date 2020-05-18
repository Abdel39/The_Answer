using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject ball;

    public int interval;
    private int clock;

    public Rigidbody2D rb;

    private Vector3 pos;

    private Quaternion quat;

    public Animator Animator;
    // Start is called before the first frame update
    private void Start()
    {
        clock = interval;
        pos = new Vector3(-0.19f, 0.16f, -0.1f);
        pos += (Vector3) rb.position;
        quat = new Quaternion(0f, 0f, 0f, 0f);
    }

    private void FixedUpdate()
    {
        if (clock == 60)
        {
            Animator.SetTrigger("end");
        }
        if (clock == 0)
        {
            clock = interval;
            Instantiate(ball,pos, quat);
        }

        clock--;
    }
}
