using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Constraints;
using UnityEngine;

public class Weapon : MonoBehaviour
{

  

    // Start is called before the first frame update
    public Transform FirePoint;

    public GameObject SpearSpawn;

    // Update is called once per frame
    public bool HaveSpear;

    void Update()
    {

       
        
    
        

        // avoir la lance et presser le bouton
        if (HaveSpear && Input.GetButtonDown("Fire3"))
        {
         // tirer
        Spear();
        

        }


}


    void Spear()
    {
        Instantiate(SpearSpawn, FirePoint.position, FirePoint.rotation);
    }
}
