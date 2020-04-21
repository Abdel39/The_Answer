using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class handeycooridination : MonoBehaviour
{
    public Enemy eye;
    public int lasthp;

    public Enemy hand;
    // Start is called before the first frame update
    void Start()
    {
        lasthp = eye.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (lasthp !=eye.hp)
        {
            Debug.Log("bim");
            hand.TakeDamage(1,false);
            lasthp--;
        }
    }
}
