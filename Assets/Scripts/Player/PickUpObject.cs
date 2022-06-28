using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] public ItemCollected itemCollected;
    [SerializeField] private AudioSource pickUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            itemCollected.increaseNum();
            pickUp.Play();
            Destroy(other.gameObject);
        }
    }
}
