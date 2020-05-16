using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_spectre_1 : MonoBehaviour
{
    private ParticleSystem spawn;

    private bool vaspawn = true;

    private GameObject fantomepref;
    // Start is called before the first frame update
    void Start()
    {
        fantomepref = GameObject.Find("Phantom");
    }

    // Update is called once per frame
    void Update()
    {
        if (vaspawn == true)
        {
            StartCoroutine(spawnéclair());
        }
    }
    
    private  IEnumerator spawnéclair()
    {
        vaspawn = false;
        yield return new WaitForSeconds(7f);
        if (GameObject.Find("éclair(Clone)") == false)
        {
            GameObject.Instantiate(fantomepref);
            vaspawn = false;
        }
        fantomepref.transform.position = this.transform.position;
        vaspawn = true;
    }
}
