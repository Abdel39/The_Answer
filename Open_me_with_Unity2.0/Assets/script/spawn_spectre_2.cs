using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_spectre_2 : MonoBehaviour
{
    private ParticleSystem spawn;

    private bool vaspawn = true;
    public float décal;
    
    private int nbspawn = -1;
    public int maxspawn;
    
    public GameObject fantomepref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vaspawn && nbspawn <= maxspawn)
        {
            StartCoroutine(spawnéclair());
            nbspawn += 1;
        }

        if (nbspawn >= maxspawn)
        {
            Destroy(this.gameObject);
        }
    }
    
    private  IEnumerator spawnéclair()
    {
        vaspawn = false;
        yield return new WaitForSeconds(7f + décal);
        fantomepref.transform.position = this.transform.position;
        GameObject.Instantiate(fantomepref);
        
        vaspawn = false;
        
        décal = 0;
        vaspawn = true;
    }
}
