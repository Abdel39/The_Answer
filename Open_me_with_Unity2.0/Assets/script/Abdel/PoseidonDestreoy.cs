using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public class PoseidonDestreoy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string n = collision.collider.tag;
        if (n == "Ennemies"|| n=="IsGround")
        {
            Destroy(collision.gameObject);
        }
    }
}
