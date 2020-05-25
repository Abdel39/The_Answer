using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCanon : MonoBehaviour
{
    
    public GameObject ball;
    
    public int turn = 1;
    public int upside = 1;

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
        pos = new Vector3(-0.19f*turn, 0.16f*upside, -0.1f);
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
                GameObject i=Instantiate(ball,pos, quat);
                i.GetComponent<Rigidbody2D>().velocity=new Vector2(-turn*10,upside*10);
                clock--;
                isattacking = false;
            }

            clock--;
        }
    }
}
