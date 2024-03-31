using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.State
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public LinkStateMachine stateMachine;
        private CharacterController controller;
        private Transform cam;

        // Gravity Variables
        [Header("Gravity Settings")]
        [SerializeField] private float gravity = -9.81f;
        private Vector3 gravityVector;

        // Movement Variables
        [Header("Movement Settings")]
        [SerializeField] private float movementSpeed = 100f;
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private float turnSmoothVelocity;
        private Vector3 moveDirection;
        private Vector3 direction;
        private float xAxis;
        private float zAxis;

        [Header("Ground Layer")]
        [SerializeField] private LayerMask groundLayer;

        // Jump Variables
        [Header("Jump Settings")]
        [SerializeField] private float initialJumpVelocity;
        [SerializeField] private float maxJumpHeight = 1.0f;
        [SerializeField] private float maxJumpTime = 0.5f;
        private Vector3 jumpVector = Vector3.zero;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main.transform;
            stateMachine = GetComponent<LinkStateMachine>();
        }

        public void Move()
        {
            controller.Move(moveDirection + gravityVector + jumpVector);
        }
        public void SetJumpVariables()
        {
            float timeToApex = maxJumpTime / 2;
            gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
            initialJumpVelocity = (maxJumpHeight) / timeToApex;
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
        }
        public void UpdateMoveDirection()
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

            else
            {
                moveDirection = Vector3.zero;
            }
        }

        public bool IsIdle()
        {
            return direction.magnitude <= 0;
        }

        public void Jump()
        {
            jumpVector.y = initialJumpVelocity * 0.5f;
        }

        public void ResetJumpVector()
        {
            jumpVector = Vector3.zero;
        }

        public void AplyGravity()
        {
            float previousYVelocity = gravityVector.y;
            float newYVelocity = gravityVector.y + (gravity * Time.fixedDeltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * 0.5f;
            gravityVector.y = nextYVelocity;
        }

        public void ResetGravityVector()
        {
            gravityVector = Vector3.zero;
            //gravity = -9.81f;
        }

        public void SetState(BaseState state)
        {
            if (stateMachine.CurrentState != state)
            {
                stateMachine.SetState(state);
            }
        }
    }
}

