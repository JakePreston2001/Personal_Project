using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float xSpeed, ySpeed, zSpeed;
    [SerializeField] private Transform Object;

    // Update is called once per frame
    void Update()
    {
        Object.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
    }
}
