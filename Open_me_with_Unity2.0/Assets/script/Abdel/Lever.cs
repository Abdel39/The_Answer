using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public BlueCanon Canon;
    public Animator Animator;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Canon.isattacking = true;
        Animator.SetTrigger("end");
        Canon.Animator.SetTrigger("end");
    }
}
