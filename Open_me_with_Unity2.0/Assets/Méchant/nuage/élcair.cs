using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class élcair : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xb;
    public int côté;
    
    
    private Vector3 position;
    private Vector3 positionperso;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xb = rb.position.x;
        
        position = rb.transform.position;
        positionperso = GameObject.Find("character").transform.position;
        
        if (positionperso.x < position.x)
        {
            côté = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(15 * côté, 0, 0);
        rb.velocity = move;
        StartCoroutine(fin());
    }

    private IEnumerator fin()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GameObject.Find(this.name));
    }
}
