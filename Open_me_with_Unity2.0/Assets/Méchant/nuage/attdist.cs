using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class attdist : MonoBehaviour
{
    private Vector2 velocity;
    
    // physique 2D du cochon
    private Rigidbody2D nuage;
    
    private float fastx;
    private float fasty;

    private Vector3 rotat = new Vector3(0, 180,0);
    private bool retourner = true;
    
    private Vector3 position;
    private Vector3 positionperso;

    private bool vatirer = true;
    public GameObject eclairprefabe;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        nuage = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        velocity = Vector2.zero;
        position = nuage.transform.position;
        positionperso = GameObject.Find("character").transform.position;

        if (positionperso.x < position.x)
        {
            if (!retourner)
            {
                nuage.transform.Rotate(rotat);
                retourner = true;
            }
        }
        else
        {
            if (retourner)
            {
                nuage.transform.Rotate(rotat);
                retourner = false;
            }
        }

        if (positionperso.x - 13 < position.x && positionperso.x + 13 > position.x)
        {
            if (positionperso.x - 10 < position.x && positionperso.x + 10 > position.x)
            {
                fastx = 0;
                if (vatirer == true)
                {
                    StartCoroutine(spawnéclair());
                }
            }
            else if (positionperso.x < position.x)
            {
                fastx = -4;
            }
            else
            {
                fastx = 4;
            }

            Vector3 move = new Vector3(fastx, nuage.velocity.y, 0);
            nuage.velocity = move;
        }
    }

    private  IEnumerator spawnéclair()
    {
        vatirer = false;
        yield return new WaitForSeconds(0.7f);
        if (GameObject.Find("éclair(Clone)") == false)
        {
            if (positionperso.x > position.x)
            {
                GameObject.Instantiate(eclairprefabe, position  + new Vector3( 01.2f, 0, 0), Quaternion.identity);
            }
            else
            {
                GameObject.Instantiate(eclairprefabe, position  + new Vector3( -01.2f, 0, 0), Quaternion.identity);
            }
            vatirer = false;
        }

        vatirer = true;
    }
}
