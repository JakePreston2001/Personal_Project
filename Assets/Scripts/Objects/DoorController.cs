using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }
    
    public void playAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("doorOpen", 0, 0);
            doorOpen = true;
            
        }
        else if (doorOpen)
        {
            doorAnim.Play("doorClose", 0, 0);
            doorOpen = false;
        }

    }
    
}
