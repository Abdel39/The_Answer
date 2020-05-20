using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_spectre_2 : MonoBehaviour
{
    private ParticleSystem spawn;

    private bool vaspawn = true;
    public float décal;
    
    private int nbspawn = 0;
    public int maxspawn;

    private bool bosson = false;
    public GameObject boss;
    
    public GameObject fantomepref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bosson)
        {
            this.transform.position = boss.transform.position;
        }
        else if (vaspawn && nbspawn <= maxspawn)
        {
            StartCoroutine(spawnéclair());
            nbspawn += 1;
        }
        else if (nbspawn > maxspawn)
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            bosson = true;
        }
    }
    
    private  IEnumerator spawnéclair()
    {
        vaspawn = false;
        yield return new WaitForSeconds(7f + décal);
        if (!bosson)
        {
            fantomepref.transform.position = this.transform.position;
            GameObject.Instantiate(fantomepref);
        }
        
        décal = 0;
        vaspawn = true;
    }
}
