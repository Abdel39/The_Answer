using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class élcair : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xb = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x > xb + 15)
        {
            Destroy(GameObject.Find(this.name));
        }
        Vector3 move = new Vector3(15, 0, 0);
        rb.velocity = move;
    }
}
