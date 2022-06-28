using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControls : MonoBehaviour
{
    [SerializeField] private GameObject Controls;
    [SerializeField] private KeyCode ToggleControl = KeyCode.C;
    private bool controlsOn = true;
    

    void Update()
    {

        if (Input.GetKeyDown(ToggleControl))
        {
            if (controlsOn)
            {
                ToggleOff();
            }
            else if (!controlsOn)
            {
                ToggleOn();
            }
        }
    }


    public void ToggleOff()
    {
        Controls.SetActive(false);
        controlsOn = false;
    }

    public void ToggleOn()
    {
        Controls.SetActive(true);
        controlsOn = true;
    }
}
