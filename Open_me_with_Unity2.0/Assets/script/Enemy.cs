using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp =10;
<<<<<<< Updated upstream

    private bool IsAlive = true;
=======
    
    public bool IsAlive = true;
    public bool isinvulnerable = false;
    public CameraShake caméra;
>>>>>>> Stashed changes

    public Transform hurtbox;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(hp+name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive)
        {
            Destroy(GameObject.Find(this.name));
        }
    }

    public void TakeDamage(int dammage, bool isinv=true)
    {
<<<<<<< Updated upstream
=======
        caméra.ShakeElapsedTime = caméra.ShakeDuration;
        
        if (isinvulnerable&&isinv)
            return;
        
>>>>>>> Stashed changes
        hp = hp -dammage;
        
        if (hp <= 0)
        {
            IsAlive = false;
        }

        Debug.Log("ouch"+name);
    }
    
}
