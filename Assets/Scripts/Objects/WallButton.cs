using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Object;
    [SerializeField] private float distanceMove;
    [SerializeField] private float speed;
    [Space]
    [SerializeField] private Transform GateObject;
    [SerializeField] private bool gateStaysOpen;
    [SerializeField] private float gateMoveHeight;
    [SerializeField] private float GateMoveSpeed;
    [SerializeField] private AudioSource click;

    private bool pressed = false;
    private float originalPosX;
    private bool OpenGate;
    private float originalGateHeight;
    private void Start()
    {
        originalPosX = Object.position.x;
        originalGateHeight = GateObject.position.y;
    }

    public void moveButton() 
    {
        pressed = true;
        
    }

    void Update()
    {
        if (pressed)
        {
            OpenGate = true;
            if (!click.isPlaying)
            {
                click.Play();
            }
            Object.transform.position += Vector3.right * speed * Time.deltaTime;
            if (Object.transform.position.x >= originalPosX + distanceMove)
            {
                Object.transform.position = new Vector3(originalPosX + distanceMove, Object.transform.position.y, Object.transform.position.z);
                pressed = false;
            }
        }
        if (!pressed)
        {
            Object.transform.position += Vector3.left * (speed/2) * Time.deltaTime;
            if (Object.transform.position.x <= originalPosX)
            {
                Object.transform.position = new Vector3(originalPosX, Object.transform.position.y, Object.transform.position.z);
            }
        }
        if (OpenGate)
        {
            GateObject.transform.position += Vector3.up * GateMoveSpeed * Time.deltaTime;
            if (GateObject.transform.position.y >= originalGateHeight + gateMoveHeight)
            {
                GateObject.transform.position = new Vector3(GateObject.transform.position.x, originalGateHeight + gateMoveHeight, GateObject.transform.position.z);
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
