using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform ButtonObjectBase;
    [SerializeField] private float distanceDown;
    [SerializeField] private float speed;
    [Space]
    [SerializeField] private Transform GateObject;
    [SerializeField] private bool gateStaysOpen;
    [SerializeField] private float distanceMove;
    [SerializeField] private float GateMoveSpeed;
    private bool pressed;
    private bool OpenGate;
    private float originalButtonHeight;
    private float originalGateHeight;

    private void Start()
    {
        originalButtonHeight = ButtonObjectBase.position.y;
        originalGateHeight = GateObject.position.y;   
    }

    private void OnTriggerEnter(Collider other)
    {
        pressed = true;
        OpenGate = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pressed = false;
        OpenGate = false;
    }

    void Update()
    {
        if (pressed) 
        {
            
            ButtonObjectBase.transform.position += Vector3.down * speed * Time.deltaTime;
            if (ButtonObjectBase.transform.position.y <= originalButtonHeight - distanceDown)
            {
                ButtonObjectBase.transform.position = new Vector3(ButtonObjectBase.transform.position.x, originalButtonHeight - distanceDown, ButtonObjectBase.transform.position.z);
            }
        }
        if (!pressed)
        {
            ButtonObjectBase.transform.position += Vector3.up * speed * Time.deltaTime;
            if (ButtonObjectBase.transform.position.y >= originalButtonHeight)
            {
                ButtonObjectBase.transform.position = new Vector3(ButtonObjectBase.transform.position.x, originalButtonHeight, ButtonObjectBase.transform.position.z);
            }
        }
        if (OpenGate)
        {
            GateObject.transform.position += Vector3.up * GateMoveSpeed * Time.deltaTime;
            if (GateObject.transform.position.y >= originalGateHeight + distanceMove)
            {
                GateObject.transform.position = new Vector3(GateObject.transform.position.x, originalGateHeight + distanceMove, GateObject.transform.position.z);
            }
        }
        if (!OpenGate && !gateStaysOpen)
        {
            GateObject.transform.position += Vector3.down * GateMoveSpeed * Time.deltaTime;
            if (GateObject.transform.position.y <= originalGateHeight)
            {
                GateObject.transform.position = new Vector3(GateObject.transform.position.x, originalGateHeight, GateObject.transform.position.z);
            }
        }
    }
}
