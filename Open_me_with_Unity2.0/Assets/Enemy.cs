using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;

    public int dammege;

    private bool IsAlive = true;

    public Transform hurtbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDammage(int dammage)
    {
        hp = -dammage;
        if (hp < 0)
        {
            IsAlive = false;
        }
    }
    
}
