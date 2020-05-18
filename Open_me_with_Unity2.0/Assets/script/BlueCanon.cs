using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCanon : MonoBehaviour
{
    
    public GameObject ball;

    public int interval=60;
    private int clock;
    public bool isattacking = false;

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
        if (isattacking)
        {
            if (clock == 0)
            {
                clock = interval;
                Instantiate(ball, pos, quat);
                clock--;
                isattacking = false;
            }

            clock--;
        }
    }
}
