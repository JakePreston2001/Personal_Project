using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Object;
    [SerializeField] private float distanceMove;
    [SerializeField] private float speed;

    private bool pressed = false;
    private float originalPosX;
    
    private void Start()
    {
        originalPosX = Object.position.x;
    }

    public void moveButton() 
    {
        pressed = true;
    }

    void Update()
    {
        if (pressed)
        {
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
    }
}
