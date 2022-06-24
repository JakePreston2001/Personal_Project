using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Transform sun;
    [SerializeField] private int daySpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        sun.Rotate(daySpeed * Time.deltaTime, 0, 0);
    }
}
