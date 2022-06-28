using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    #region serialised Fields
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform Player;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource Runfootstep;
    [Space]
    [Space]
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] public float Gravity;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private int maxNumOfJumps;
    [SerializeField] private KeyCode Run = KeyCode.LeftShift;
    [Space]
    [Space]
    [SerializeField] private Transform cam;
    [Space]
    [Space]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [Space]
    [Space]
    [SerializeField] private CinemachineFreeLook vcam;
    [SerializeField] private float initialFOV;
    [SerializeField] private float runFOV;
    [SerializeField] private float FOVincrease;
    #endregion

    #region private variables
    private int numberOfJumps;
    private bool inAir;
    private bool jumped;
    private bool isRunning;

    private float jumpAnim;

    private float currantFOV;
    

    private bool isGrounded;
    private float turnSmoothVelocity;
    private Vector3 velocity;

    private Animator animator;
    #endregion


    #region methods
    private void Start()
    {
        animator = GetComponent<Animator>();
        vcam.m_CommonLens = true;
        currantFOV = initialFOV;
    }

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        #region initial input, run and ground check
        if (Player.parent != null && !isGrounded)
        {
            velocity += Vector3.up * Gravity * Time.deltaTime;
        }
        if (velocity.y < 0)
        {
            velocity += Vector3.up * Gravity * (fallMultiplier - 1) * Time.deltaTime;
            //jumpAnim = 1;
            inAir = true;
            jumped = true;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
            numberOfJumps = maxNumOfJumps;
            jumpAnim = 0;
        }

        if (Input.GetKeyDown(Run))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(Run))
        {
            isRunning = false;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        #endregion

        #region if moving
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir = AdjustVelocitytoSlope(moveDir);
            if (isRunning)
            {
                controller.Move(moveDir.normalized * RunSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude + 1);
                if (currantFOV >= runFOV)
                {
                    currantFOV = runFOV;
                }
                else
                {
                    currantFOV += FOVincrease * Time.deltaTime;
                }
                if (!Runfootstep.isPlaying && isGrounded)
                {
                    Runfootstep.Play();
                }
            }
            else if (!isRunning)
            {
                controller.Move(moveDir.normalized * WalkSpeed * Time.deltaTime);
                animator.SetFloat("Speed", direction.magnitude);
                if (currantFOV <= initialFOV)
                {
                    currantFOV = initialFOV;
                }
                else
                {
                    currantFOV -= FOVincrease * Time.deltaTime;
                }
                if (!footstep.isPlaying && isGrounded)
                {
                    footstep.Play();
                }
            }
        }
        else 
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
        #endregion

        #region jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || numberOfJumps > 0))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity);
            jumpAnim = 2;
            numberOfJumps--;
            inAir = true;
            jumped = true;
        }
        if (isGrounded && !inAir && jumped)
        {
            jumpAnim = 1;
            inAir = false;
            jumped = false;
        }
        if (!isGrounded)
        {
            jumpAnim = 2;
            footstep.Stop();
            Runfootstep.Stop();
        }
        #endregion

        #region final checks, jump animation set, gravity applied
        animator.SetFloat("Jump", jumpAnim);
        velocity.y += 0.5f * Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion

        vcam.m_Lens.FieldOfView = currantFOV;
    }
    #endregion

    private Vector3 AdjustVelocitytoSlope(Vector3 velocity)
    {
        var ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f)) 
        {
            var slopRot = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedVelocity = slopRot * velocity;

            if (adjustedVelocity.y < 0)
            {
                return adjustedVelocity;
            }
        }
        return velocity;
    }
}
