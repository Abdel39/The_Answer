using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private Transform playertransform;
    // Start is called before the first frame update
    void Start()
    {
        playertransform = GameObject.Find("character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playertransform.position.x,
            playertransform.position.y,
            playertransform.position.z);
    }
}
