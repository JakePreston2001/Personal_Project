using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    //[SerializeField] private Transform Player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CharacterController controller;

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.enabled = false;
            other.transform.position = spawnPoint.position;
            controller.enabled = true;
        }
        else {
            other.transform.position = spawnPoint.position;
        }
    }
}
