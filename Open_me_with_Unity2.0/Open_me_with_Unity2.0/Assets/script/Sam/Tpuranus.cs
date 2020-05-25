using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tpuranus : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D info)
    {
        playermoves player = info.GetComponent<playermoves>();
        if (info!=null)
        {
            SceneManager.LoadScene("fântome boss battle");
            Debug.Log("boom");
        }
            
        
    }
}
