using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    [SerializeField] private int rayLength;
    [SerializeField] private LayerMask layerMaksInteract;
    [SerializeField] private string excludeLayerName = null;

    private voiceInteractController RayCastNPC;
    private DoorController RayCastDoor;
    private WallButton RayCastButton;
    [SerializeField] private KeyCode Interact = KeyCode.E;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableOpen = "InteractableOpen";
    private const string interactableNPC = "InteractableNPC";
    private const string wallButton = "WallButton";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaksInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) 
        {
            if (hit.collider.CompareTag(interactableNPC)) 
            {
                if (!doOnce)
                {
                    RayCastNPC = hit.collider.gameObject.GetComponent<voiceInteractController>();
                    crosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(Interact) && !RayCastNPC.audio.isPlaying) 
                {
                    RayCastNPC.audio.Play();
                }
                if (Pause.GameIsPaused)
                {
                    RayCastNPC.audio.Pause();
                }
            }
            if (hit.collider.CompareTag(interactableOpen)) 
            {
                if (!doOnce)
                {
                    RayCastDoor = hit.collider.gameObject.GetComponent<DoorController>();
                    crosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(Interact))
                {
                    RayCastDoor.playAnimation();
                }
                
            }
            if (hit.collider.CompareTag(wallButton))
            {
                if (!doOnce)
                {
                    RayCastButton = hit.collider.gameObject.GetComponent<WallButton>();
                    crosshairChange(true);
                }
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(Interact))
                {
                    RayCastButton.moveButton();
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                crosshairChange(false);
                doOnce = false;
            }
        }

    }

    void crosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.blue;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
