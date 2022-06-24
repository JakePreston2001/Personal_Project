using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class ControlWeight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rig rig;
    [SerializeField] private float lookSpeed;
    private bool lookAtPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lookAtPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lookAtPlayer = false;
        }
    }
    private void Update()
    {
        if (lookAtPlayer)
        {
            if (rig.weight < 1)
            {
                rig.weight += lookSpeed * Time.deltaTime;
            }
            else
            {
                rig.weight = 1;
            }
        }
        else 
        {
            if (rig.weight > 0)
            {
                rig.weight -= lookSpeed * Time.deltaTime;
            }
            else
            {
                rig.weight = 0;
            }
        }
        
    }
}
