using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] public ItemCollected itemCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            itemCollected.increaseNum();
            Destroy(other.gameObject);
        }
    }
}
