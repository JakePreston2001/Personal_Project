using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float climbSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    private bool inside;
    private bool climbUp;
    private bool climbDown;
    private float climbAnim;
    private Animator animator;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        inside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            playerMovement.enabled = false;
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            playerMovement.enabled = true;
            inside = false;
        }
    }

    private void Update()
    {
        
        if (inside)
        {
            if (Input.GetKeyDown(moveUp))
            {
                climbUp = true;
            }
            if (Input.GetKeyUp(moveUp))
            {
                climbUp = false;
            }
            if (Input.GetKeyDown(moveDown))
            {
                climbDown = true;
            }
            if (Input.GetKeyUp(moveDown))
            {
                climbDown = false;
            }

            if (climbUp)
            {
                Player.transform.position += Vector3.up * Time.deltaTime * climbSpeed;
                climbAnim = 1;
            }

            else if (climbDown)
            {
                Player.transform.position += Vector3.down * Time.deltaTime * climbSpeed;
                climbAnim = 2;
            }
            else 
            {
                climbAnim = 0;
            }
        }
        animator.SetFloat("Jump", climbAnim);
    }

}
