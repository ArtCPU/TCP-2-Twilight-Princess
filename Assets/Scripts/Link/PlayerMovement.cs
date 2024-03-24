using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform cam;

    // Gravity Variables
    [Header ("Gravity Settings")]
    [SerializeField] private float gravity = -9.81f;
    private Vector3 gravityVector;

    // Movement Variables
    [Header ("Movement Settings")]
    [SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;
    private Vector3 moveDirection;
    private Vector3 direction;
    private float xAxis;
    private float zAxis;

    [Header("Ground Layer")]
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    // Jump Variables
    [Header("Jump Settings")]
    [SerializeField] private float initialJumpVelocity;
    [SerializeField] private float maxJumpHeight = 1.0f;
    [SerializeField] private float maxJumpTime = 0.5f;
    private Vector3 jumpVector = Vector3.zero;
    private bool isJumping = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        SetJumpVariables();
    }
    private void FixedUpdate()
    {
        Debug.Log(IsGrounded());
        IsGrounded();
        UpdateMoveDirection();
        controller.Move(moveDirection + gravityVector + jumpVector);
        AplyGravity();
        TryJump();
    }

    private void SetJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    private bool IsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
        return isGrounded;
    }
    private void UpdateMoveDirection()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        direction = new Vector3(xAxis, 0f, zAxis).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float newAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, newAngle, 0f);

            moveDirection = (Quaternion.Euler(0f, newAngle, 0f) * Vector3.forward).normalized * movementSpeed * Time.fixedDeltaTime;
        }

        else moveDirection = Vector3.zero;
    }

    private void TryJump()
    {
        if (!isJumping && !isGrounded)
        {
            isJumping = true;
            jumpVector.y = initialJumpVelocity * 0.5f;
        }
        else if (isJumping && isGrounded)
        {
            jumpVector = Vector3.zero;
            isJumping = false;
        }
    }
    private void AplyGravity()
    {
        if (isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -0.5f;
        }
        else
        {
            float previousYVelocity = gravityVector.y;
            float newYVelocity = gravityVector.y + (gravity * Time.fixedDeltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * 0.5f;
            gravityVector.y = nextYVelocity;
        }  
    }
}
