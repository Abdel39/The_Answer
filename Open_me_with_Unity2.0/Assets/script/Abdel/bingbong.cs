using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.VersionControl;
using UnityEngine;
using Object = UnityEngine.Object;

public class bingbong : MonoBehaviour
{
    public Object obj;

    public Collider2D box;

    public Enemy Enemy;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity=new Vector2(speed,0);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IsGround" || other.tag == "player")
        {
            Debug.Log(other.transform.position.y);
            Enemy.IsAlive = false;
        }
    }
}
