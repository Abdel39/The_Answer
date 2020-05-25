using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator _animator;
    public bool On;
    public flipswitch switchcontrol;
    void Start()
    {
        On = true;
    }

    // Update is called once per frame
    void Update()
    {
        On = switchcontrol.On;
        
        
        if (On)
        {
            _animator.SetBool("Off",false);
        }
        else
        {
            _animator.SetBool("Off",true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switchcontrol.FlipSwitch();
        
    }
}
