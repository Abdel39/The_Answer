using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_fant : MonoBehaviour
{
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            if (GameObject.Find("Particle System (1)") == null)
            {
                start = true;
                this.transform.position = new Vector3(-12, -7);
            }
        }
        else
        {
            
        }
    }
}