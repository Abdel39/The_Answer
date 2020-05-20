using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_fant : MonoBehaviour
{
    private bool start = false;
    
    private bool vaspawn = true;
    private bool effect1 = true;

    public GameObject effetspawn;
    
    public GameObject fantomepref;
    public GameObject fantomepref2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            if (!effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission)
            {
                start = true;
                this.transform.position = new Vector3(-12, -7);
            }
        }
        else
        {
            if (effect1)
            {
                spawnfant();
                effect1 = false;
            }
        }
    }
    
    
    
    private  IEnumerator spawnfant()
    {
        effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
        vaspawn = false;
        yield return new WaitForSeconds(7f);
        
        fantomepref.transform.position = new Vector3(-12, 1);
        GameObject.Instantiate(fantomepref);

        effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        
        vaspawn = false;
        vaspawn = true;
    }
}