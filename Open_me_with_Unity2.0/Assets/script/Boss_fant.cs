using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss_fant : MonoBehaviour
{
    private bool start = false;

    private bool vaattendre = true;
    private bool vaspawn = true;
    private bool effect1 = true;
    
    
    private bool retourner = true;
    private Vector3 rotat = new Vector3(0, 180,0);

    public GameObject effetspawn;
    
    public GameObject fantomepref;
    public GameObject fantomepref2;

    public GameObject hero;
    
    private List<Vector3> teleport = new List<Vector3>(4);

    public Enemy Boss;

    public Vector3 positionperso;
    // Start is called before the first frame update
    void Start()
    {
        teleport.Add(new Vector3(-12, -7));
        teleport.Add(new Vector3(12, -7));
        teleport.Add(new Vector3(-11, 0));
        teleport.Add(new Vector3(11, 0));
        teleport.Add(new Vector3(0, 7));
    }

    // Update is called once per frame
    void Update()
    {
        if (positionperso.x - 1.2 < this.transform.position.x && positionperso.x + 1.2 > this.transform.position.x)
        {
            
        }
        else if (positionperso.x < this.transform.position.x)
        {
            if (!retourner)
            {
                this.transform.Rotate(rotat);
                retourner = true;
            }
        }
        else
        {
            if (retourner)
            {
                this.transform.Rotate(rotat);
                retourner = false;
            }
        }
        
        if (!start)
        {
            if (!effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission)
            {
                start = true;
                this.transform.position = teleport[Random.Range(0, 4)];
            }
        }
        else
        {
            if (effect1)
            {
                Boss.isinvulnerable = false;
                effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = true;
                if (vaspawn)
                {
                    StartCoroutine(spawnfant());
                    if (Boss.hp < 10)
                    {
                        StartCoroutine(spawnfant());
                    }

                    if (Boss.hp < 5)
                    {
                        StartCoroutine(spawnfant());
                    }
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
        this.transform.position = teleport[Random.Range(0, 4)];
    }

    private IEnumerator spawnfant()
    {
        vaspawn = false;
        yield return new WaitForSeconds(3f);
        if (hero.transform.position.x > this.transform.position.x)
        {
            fantomepref.transform.position = this.transform.position + new Vector3(3, 0);
        }
        else
        {
            fantomepref.transform.position = this.transform.position + new Vector3(-3, 0);
        }

        GameObject.Instantiate(fantomepref);
        effetspawn.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

        Boss.isinvulnerable = true;
        effect1 = false;
        vaspawn = true;
    }
}