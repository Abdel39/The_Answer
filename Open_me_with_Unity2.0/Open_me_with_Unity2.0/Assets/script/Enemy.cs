using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int hp =10;
    public bool IsAlive = true;
    public bool isinvulnerable = false;
    public CameraShake caméra;
    public bool launchVictoryIfKilled = false;

    public Transform hurtbox;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(hp+name);
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive)
        {
            Destroy(GameObject.Find(this.name));
            if (launchVictoryIfKilled)
            {
               SceneManager.LoadScene("victory");
                
            }
        }
    }

    public void TakeDamage(int dammage, bool isinv=true)
    {
        if (caméra!=null)
            caméra.ShakeElapsedTime = caméra.ShakeDuration;
        
        if (isinvulnerable&& isinv)
            return;
        if (caméra != null)
            caméra.ShakeElapsedTime = caméra.ShakeDuration;
        
        if (isinvulnerable&&isinv)
            return;
        hp = hp -dammage;
        
        hp = hp -dammage;
        Debug.Log("yep");
        if (hp <= 0)
        {
            IsAlive = false;
            audio.Play();
        }

        
        Debug.Log("ouch " + name);
    }
    
}
