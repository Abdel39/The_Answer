using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_spectre_1 : MonoBehaviour
{
    private ParticleSystem spawn;
    private bool vaspawn = true;
    
    private int nbspawn = 0;
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
        }
        else if (nbspawn > maxspawn)
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
    
    private  IEnumerator spawnéclair()
    {
        vaspawn = false;
        yield return new WaitForSeconds(7f);
        if (gameObject.GetComponent<ParticleSystem>().enableEmission)
        {
            fantomepref.transform.position = this.transform.position;
            GameObject.Instantiate(fantomepref);
        }
        
        nbspawn += 1;
        vaspawn = true;
    }
}
