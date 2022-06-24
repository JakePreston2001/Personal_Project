using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    [SerializeField] private float ySpeed;
    [SerializeField] private Transform Object;
    [SerializeField] private GameObject Target;
    // Update is called once per frame
    void FixedUpdate()
    {
        //Object.Rotate(xAngle * Time.deltaTime,yAngle * Time.deltaTime, zAngle * Time.deltaTime);
        transform.RotateAround(Target.transform.position, Vector3.up, ySpeed * Time.deltaTime);
    }
}
