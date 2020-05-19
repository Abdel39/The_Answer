using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_spectre_2 : MonoBehaviour
{
    private ParticleSystem spawn;

    private bool vaspawn = true;
    public float décal;
    
    public GameObject fantomepref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vaspawn)
        {
            StartCoroutine(spawnéclair());
        }
    }
    
    private  IEnumerator spawnéclair()
    {
        vaspawn = false;
        yield return new WaitForSeconds(7f + décal);
        
        GameObject.Instantiate(fantomepref);
        
        vaspawn = false;
        fantomepref.transform.position = this.transform.position;
        décal = 0;
        vaspawn = true;
    }
}
