using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipswitch : MonoBehaviour
{
    // Start is called before the first frame update

    public bool On;

    public void FlipSwitch()
    {
        On = !On;
    }
    
    
}
