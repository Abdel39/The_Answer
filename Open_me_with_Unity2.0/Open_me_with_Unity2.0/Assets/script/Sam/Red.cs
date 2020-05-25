using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    private bool on;
    private Collider2D box;
    public Switch Switch;
    public Animator animator;
    void Start()
    {
        on = false;
        box = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        on = Switch.On;

        if (on)
        {
            animator.SetBool("Off", true);
            
            box.enabled = true;
        }
        else
        {
            animator.SetBool("Off",false);
            box.enabled = false;
        }
        
    }
}
