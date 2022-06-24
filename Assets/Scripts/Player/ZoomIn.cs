using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomIn : MonoBehaviour
{
    [SerializeField] private KeyCode Zoom = KeyCode.LeftControl;
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;
    //[SerializeField] private Camera cam;
    private bool zooming;
    [SerializeField] private CinemachineFreeLook vcam;

    // Update is called once per frame
    void Update()
    {
        vcam.m_CommonLens = true;
        if (Input.GetKeyDown(Zoom))
        {
            zooming = true;
        }
        if (Input.GetKeyUp(Zoom))
        {
            zooming = false;
        }

        if (zooming)
        {
            vcam.m_Lens.FieldOfView = maxFOV;
        }
        else 
        {
            vcam.m_Lens.FieldOfView = minFOV;
        }

    }
}
