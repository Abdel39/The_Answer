using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus_boss : MonoBehaviour
{
    
    // physique 2D du phantom
    private Rigidbody2D phantom;
    
    private float fastx;
    private float fasty;

    private Vector3 rotat = new Vector3(0, 180,0);
    private bool retourner = true;

    private Vector3 position;
    public GameObject perso;

    private bool Dash = false;
    private bool reload = false;
    private bool Dashatt = false;

    private float test;
    // Start is called before the fi
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        phantom = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // retournement
        if (perso.transform.position.x - 1.2 < position.x && perso.transform.position.x + 1.2 > position.x)
        {
            
        }
        else if (perso.transform.position.x < position.x)
        {
            if (!retourner)
            {
                this.transform.Rotate(rotat);
                retourner = true;
            }
        }
        else
        {
            if (retourner)
            {
                this.transform.Rotate(rotat);
                retourner = false;
            }
        }
        
        // déplacement x, y
        if (!Dash)
        {
            if (perso.transform.position.x - 0.8 < position.x && perso.transform.position.x + 0.8 > position.x)
            {
                fastx = 0;
            }
            else if (perso.transform.position.x < position.x)
            {
                fastx = -7;
            }
            else
            {
                fastx = 7;
            }
            
            if (perso.transform.position.y - 0.8 < position.y && perso.transform.position.y + 0.8 > position.y)
            {
                fasty = 0;
            }
            else if (perso.transform.position.y < position.y)
            {
                fasty = -7;
            }
            else
            {
                fasty = 7;
            }
            Vector3 move = new Vector3(fastx, fasty, 0);
            phantom.velocity = move;
        }
        
        // dash
        test = perso.transform.position.x - position.x;
        if (test <= 5 || test >= 5)
        {
            if (!Dashatt)
            {
                StartCoroutine(Dasheffet());
            }

            if (reload)
            {
                StartCoroutine(attend());
            }
        }
    }

    // 4sec de rechargement du dash
    private IEnumerator attend()
    {
        reload = false;
        yield return new WaitForSeconds(4f);

        Dashatt = false;
    }

    // script Dash
    private IEnumerator Dasheffet()
    {
        Dash = true;
        Vector3 move = new Vector3(0, 0, 0);
        phantom.velocity = move;
        
        Dashatt = true;
        yield return new WaitForSeconds(2f);
        position.y = perso.transform.position.y;
        
        reload = true;
        Dash = false;
    }
}
