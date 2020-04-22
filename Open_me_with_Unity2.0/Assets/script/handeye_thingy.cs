using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.Networking;

public class handeye_thingy : MonoBehaviour
{
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject platform5;
    public GameObject platform6;

    public Object plat1;
    public Object plat2;
    public Object plat3;
    public Object plat4;
    public Object plat5;
    public Object plat6;

    public Object lazor;
    
    public int isdestroying = 0;
    public bool isDestroyed = false;
    public bool islasering = false;

    public int movingclock;
    public int lazerclock;
    public int lazering;
    public int repar;

    public int desroymax = 100;
    public int maxclock = 900;
    public int maxlazer = 150;
    public int lezzer = 90;
    public int reparmax = 300;

    public int whatisdestroyed;
    public bool goingup = true;
    
    private Rigidbody2D rb;

    public Animator hand;
    public Animator chronos;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.velocity=new Vector2(0,10);
        movingclock = maxclock;
        lazerclock = maxlazer;
        plat1=Instantiate(platform1,new Vector3(-6.4f,-1f,0f), new Quaternion(0f,0f,0f,0f));
        plat2=Instantiate(platform2,new Vector3(-5.5f,-6f,0f), new Quaternion(0f,0f,0f,0f));
        plat3=Instantiate(platform3,new Vector3(-18f,-3f,0f), new Quaternion(0f,0f,0f,0f));
        plat4=Instantiate(platform4,new Vector3(-14.7f,2.6f,0f), new Quaternion(0f,0f,0f,0f));
        plat5=Instantiate(platform5,new Vector3(4.2f,-3.4f,0f), new Quaternion(0f,0f,0f,0f));
        plat6=Instantiate(platform6,new Vector3(6.4f,1.69f,0f), new Quaternion(0f,0f,0f,0f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isdestroying>0)
        {
            isdestroying--;
            if (rb.position.y < 15)
            {
                rb.velocity= new Vector2(0,100);
            }
            else
            {
                rb.velocity=Vector2.zero;
            }
        }
        else if (isdestroying==0)
        {
            Destroyed();
            isDestroyed = true;
            repar = reparmax;
            lazerclock = maxlazer;
            isdestroying--;
            rb.velocity= new Vector2(0,-40);
            chronos.SetTrigger("need_help");
        }
        else
        {
            if (isDestroyed)
            {
                if (repar == 0)
                {
                    switch (whatisdestroyed)
                    {
                        case 1 :
                            plat1=Instantiate(platform1,new Vector3(-6.4f,-1f,0f), new Quaternion(0f,0f,0f,0f));
                            plat2=Instantiate(platform2,new Vector3(-5.5f,-6f,0f), new Quaternion(0f,0f,0f,0f));
                            break;
                        case 2 :
                            plat3=Instantiate(platform3,new Vector3(-18f,-3f,0f), new Quaternion(0f,0f,0f,0f));
                            plat4=Instantiate(platform4,new Vector3(-14.7f,2.6f,0f), new Quaternion(0f,0f,0f,0f));
                            break;
                        case 3 :
                            plat5=Instantiate(platform5,new Vector3(4.2f,-3.4f,0f), new Quaternion(0f,0f,0f,0f));
                            plat6=Instantiate(platform6,new Vector3(6.4f,1.69f,0f), new Quaternion(0f,0f,0f,0f));
                            break;
                    }

                    isDestroyed = false;
                }
                else
                {
                    repar--;
                }
            }

            if (movingclock == 0)
            {
                movingclock = maxclock;
                isdestroying = desroymax;
                whatisdestroyed = Random.Range(1, 4);
                switch (whatisdestroyed)
                {
                 case 1:
                     hand.SetTrigger("centre");
                     break;
                 case 2:
                     hand.SetTrigger("gauche");
                     break;
                 case 3:
                     hand.SetTrigger("droite");
                     break;
                }
                rb.velocity= new Vector2(0,100);
            }

            if (lazerclock == 0)
            {
                lazering = lezzer;
                lazerclock--;
                rb.velocity= Vector2.zero;
            }
            else if (lazering > 0)
            {
                lazering--;
            }
            else if (lazering == 0)
            {
                Lazor();
                lazering--;
                lazerclock = Random.Range(100,200);
                rb.velocity = new Vector2(0, 10);
            }
            else
            {
                Move();
                lazerclock--;
            }
            movingclock--;

        }
    }

    public void Destroyed()
    {
        switch (whatisdestroyed)
        {
            case 1 :
                Destroy(plat1);
                Destroy(plat2);
                break;
            case 2 :
                Destroy(plat3);
                Destroy(plat4);
                break;
            case 3 :
                Destroy(plat5);
                Destroy(plat6);
                break;
        }
    }

    public void Lazor()
    {
        Instantiate(lazor, new Vector3(14f, rb.position.y + 0.2f),new Quaternion(0f,0f,0f,0f));
    }

    public void Move()
    {
        float y = rb.position.y;
        if (y > 5 || y < -5)
        {
            rb.velocity = Vector2.zero;
            if (y > 0)
            {
                goingup = false;
                rb.velocity = new Vector2(0, -10);
            }
            else
            {
                goingup = true;
                rb.velocity = new Vector2(0, 10);
            }
        }
        else
        {
            if (goingup)
            {
                rb.velocity = new Vector2(0, 10);
            }
            else
            {
                rb.velocity = new Vector2(0, -10);
            }
        }
    }
}
