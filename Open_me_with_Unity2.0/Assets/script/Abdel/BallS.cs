using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallS : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "IsGround" || other.collider.tag == "Ennemies")
        {
            Destroy(gameObject);
        }
    }
}
