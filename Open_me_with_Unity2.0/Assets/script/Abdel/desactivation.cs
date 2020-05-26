using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivation : MonoBehaviour
{
    public Enemy Enemy;
    public GameObject Hades;
    public GameObject shield;
    private int lifepoint;
    void Start()
    {
        lifepoint = Enemy.hp;
        shield = GameObject.Find("shield");
    }

    // Update is called once per frame
    void Update()
    {
        if (lifepoint != Enemy.hp)
        {
            lifepoint = Enemy.hp;
            transform.position+= Vector3.down*1000;
            Destroy(shield);
        }
    }
}
