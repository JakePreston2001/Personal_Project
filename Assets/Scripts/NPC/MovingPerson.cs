using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPerson : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float movespeed;
    [SerializeField] private int target;
    [SerializeField] private int RotationSpeed;
    [SerializeField] private int speed;
    [SerializeField] private float offSet;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    private Animator animator;
    private bool isGrounded;
    private Vector3 velocity;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, movespeed * Time.deltaTime);
        //transform.LookAt(waypoints[target].position);
        var targetRotation = Quaternion.LookRotation(waypoints[target].transform.position - transform.position);
        var rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);

        float NPCx = transform.position.x;
        float NPCz = transform.position.z;
        NPCx = Mathf.Round(NPCx * 10) / 10;
        NPCz = Mathf.Round(NPCz * 10) / 10;

        float waypointX = waypoints[target].position.x;
        float waypointZ = waypoints[target].position.z;
        waypointX = Mathf.Round(waypointX * 10) / 10;
        waypointZ = Mathf.Round(waypointZ * 10) / 10;

        if (transform.position.magnitude > 0.01) 
        {
            animator.SetFloat("Speed", transform.position.magnitude);
        }

        //Debug.Log("NPCx: " + NPCx + "; waypointX: " + waypointX + "/n NPCz: " + NPCz + "; waypointZ: " + waypointZ);

        if ((NPCx <= (waypointX + offSet)) && (NPCx >= (waypointX - offSet)) && (NPCz <= (waypointZ + offSet)) && (NPCz >= (waypointZ - offSet)))
        {
            int CurrentTarget = target;
            target = Random.Range(0, waypoints.Count);
            if (target == CurrentTarget)
            {
                do
                {
                    target = Random.Range(0, waypoints.Count - 1);
                } while (target == CurrentTarget);
            }
        }
        
        //transform.position = (velocity * speed * Time.deltaTime).normalized;
    }
}
