using Cinemachine;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PhysicsProcessor : MonoBehaviour
{
    public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; } = -9.81f;

    private Vector3 gravityVector;
    private Vector3 movementVector;
    private Vector3 jumpVector;
    private Vector3 cameraRelatedMovementVector;
    private float initialGravity;
    private Camera camera;
    public Vector3 GravityVector => gravityVector;
    public Vector3 MovementVector => movementVector;
    public Vector3 JumpVector => jumpVector;

    public bool IsGrounded { get; private set; }
    public bool IsOnStairs { get; private set; }

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        initialGravity = Gravity;
        camera = Camera.main;
    }
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        ApplyGravity();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector3 direction = GravityVector + MovementVector + JumpVector;
        //cameraRelatedMovementVector = ConvertToCameraSpace(direction);
        CharacterController.Move(direction);
    }

    private void Update()
    {
        IsGrounded = CharacterController.isGrounded;
    }

    private void ApplyGravity()
    {
        if (CharacterController.isGrounded)
        {
            Gravity = initialGravity;
            jumpVector = Vector3.zero;
            ResetGravityVector();
            return;
        }

        float previousYVelocity = GravityVector.y;
        float newYVelocity = GravityVector.y + (Gravity * Time.fixedDeltaTime);
        float nextYVelocity = (previousYVelocity + newYVelocity) * 0.5f;
        gravityVector.y = nextYVelocity;
    }

    public void ResetGravityVector()
    {
        gravityVector = Vector3.down * 0.1f;
    }

    public void ResetHorizontalVelocity()
    {

    }

    public void ResetVerticalVelocity()
    {

    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementVector = direction;
    }

    public void SetMoveDirectionCameraBased(Vector3 direction, ref float turnVelocity, float turnTime, float movementSpeed)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime/10);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        movementVector = moveDirection.normalized * movementSpeed * Time.fixedDeltaTime;
    }

    public Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
        float currentYValue = vectorToRotate.y;

        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 cameraForwardZProduct = vectorToRotate.z * cameraForward;
        Vector3 cameraRightXProduct = vectorToRotate.x * cameraRight;
        
        Vector3 vectorRotatedToCameraSpace = cameraForwardZProduct + cameraRightXProduct;
        vectorRotatedToCameraSpace.y = currentYValue;
        return vectorRotatedToCameraSpace;

    }

    public void StopMovement()
    {
        movementVector = Vector3.zero;
    }

    public void ApplyVerticalForce(float velocity)
    {
        //CharacterController.Move(Vector3.up * velocity * intensity);
        jumpVector.y = velocity;
    }

    public float VerticalVelocityVerletIntegration(Vector3 velocity, float initialVerticalVelocity)
    {
        float previousVelocity = velocity.y;
        float newYVelocity = velocity.y + initialVerticalVelocity;
        float nextYVelocity = (previousVelocity + newYVelocity) * 0.5f;

        return nextYVelocity;
    }

    public void SetGravity(float value)
    {
        Gravity = value;
    }

    public void SetJumpVector(float value)
    {
        jumpVector.y = value;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IsOnStairs = hit.gameObject.layer == LayerMask.NameToLayer("Stairs");
    }
}
