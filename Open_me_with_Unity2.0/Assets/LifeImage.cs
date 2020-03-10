using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateHeartImage(int currentLife)
    {
        switch (currentLife)
        {
            case 0:
                Debug.Log("0 lp");
                break;
            case 1:
                Debug.Log("1 lp");
                break;
            case 2:
                Debug.Log("2 lp");
                break;
            case 3 :
                Debug.Log("3 lp");
                break;
        }
    }
}
