using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity=new Vector2(-1,1)*speed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string n = collision.collider.tag;
        if (n == "Ennemies")
        {
            collision.collider.GetComponent<Enemy>().TakeDamage(1,false);
        }

        if (n == "IsGround")
        {
            Destroy(this.gameObject);
        }
    }
}
