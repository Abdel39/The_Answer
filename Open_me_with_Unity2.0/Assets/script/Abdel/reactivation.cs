using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactivation : MonoBehaviour
{
    public Enemy Enemy;
    public GameObject shield;
    private int lifepoint;
    public desactivation Desactivation;
    void Start()
    {
        lifepoint = Enemy.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifepoint != Enemy.hp)
        {
            lifepoint = Enemy.hp;
            GameObject i=Instantiate(shield,transform);
            Desactivation.shield = i;
        }
    }
}
