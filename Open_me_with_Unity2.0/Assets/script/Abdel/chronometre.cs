using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chronometre : MonoBehaviour
{
    public int TimeBeforeDestruction;

    // Update is called once per frame
    void Update()
    {
        TimeBeforeDestruction--;
        if (TimeBeforeDestruction<=0)
            Destroy(gameObject);
    }
}
