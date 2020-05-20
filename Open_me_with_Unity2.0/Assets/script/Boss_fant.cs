using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_fant : MonoBehaviour
{
    private bool start = false;

    private bool vaattendre = true;
    private bool vaspawn = true;
    private bool effect1 = true;

    public GameObject effetspawn;
    
    public GameObject fantomepref;
    public GameObject fantomepref2;

    public Enemy Boss;
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
                Boss.isinvulnerable = true;
                effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
                if (vaspawn)
                {
                    StartCoroutine(spawnfant());
                }
            }
            else
            {
                effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = false;
                if (vaattendre)
                {
                    StartCoroutine(attend());
                }
            }
        }
    }

    private IEnumerator attend()
    {
        vaattendre = false;
        yield return new WaitForSeconds(3f);
        effect1 = true;
        vaattendre = true;
    }
    
    private  IEnumerator spawnfant()
    {
        vaspawn = false;
        yield return new WaitForSeconds(3f);
        
        fantomepref.transform.position = this.transform.position + new Vector3(5, 1);
        GameObject.Instantiate(fantomepref);
        effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

        Boss.isinvulnerable = false;
        effect1 = false;
        vaspawn = true;
    }
}