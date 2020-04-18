using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class tourellescript : MonoBehaviour
{

    private Rigidbody2D tourelles;
    
    private Vector3 position;
    private Vector3 positionperso;
    
    private bool vatirer = true;
    
    public GameObject balleprefabe;
    // Start is called before the first frame update
    void Start()
    {
        tourelles = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        position = tourelles.transform.position;
        positionperso = GameObject.Find("character").transform.position;
        
        if (vatirer == true)
        {
            StartCoroutine(spawnballe());
        }
    }
    
    private  IEnumerator spawnballe()
    {
        vatirer = false;
        yield return new WaitForSeconds(0.2f);
        if (positionperso.x > position.x)
        { 
            GameObject.Instantiate(balleprefabe, position  + new Vector3( 01.2f, 0, 0), Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(balleprefabe, position  + new Vector3( -01.2f, 0, 0), Quaternion.identity);
        }

        vatirer = true;
    }
}
