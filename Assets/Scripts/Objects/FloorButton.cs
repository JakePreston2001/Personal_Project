using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Object;
    [SerializeField] private float distanceDown;
    [SerializeField] private float speed;
    private bool pressed;
    private float originalHeight;

    private void Start()
    {
        originalHeight = Object.position.y;   
    }

    private void OnTriggerEnter(Collider other)
    {
        pressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pressed = false;
    }

    void Update()
    {
        if (pressed) 
        {
            Object.transform.position += Vector3.down * speed * Time.deltaTime;
            if (Object.transform.position.y <= originalHeight-distanceDown)
            {
                Object.transform.position = new Vector3(Object.transform.position.x, originalHeight-distanceDown, Object.transform.position.z);
            }
        }
        if (!pressed)
        {
            Object.transform.position += Vector3.up * speed * Time.deltaTime;
            if (Object.transform.position.y >= originalHeight)
            {
                Object.transform.position = new Vector3(Object.transform.position.x, originalHeight, Object.transform.position.z);
            }
        }
    }
}
