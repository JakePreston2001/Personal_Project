using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidBody : MonoBehaviour
{
    [SerializeField] private float pushPower;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }
        if (!body.CompareTag("InteractableNPC"))
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, hit.moveDirection.y, hit.moveDirection.z);

            body.velocity = pushDir * pushPower;
        }
        /*
        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }
        */
        
    }
}
