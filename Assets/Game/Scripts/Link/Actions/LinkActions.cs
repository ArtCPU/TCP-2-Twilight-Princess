using System.Collections;
using System.Collections.Generic;
using Game.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class LinkActions
{
    private PhysicsProcessor physicsProcessor;
    private LinkMovementData movementData;
    private LinkInputController inputController;
    private float turnSmoothVelocity;
    public LinkActions(PhysicsProcessor physicsProcessor, LinkMovementData  movementData, LinkInputController inputController)
    {
        this.physicsProcessor = physicsProcessor;
        this.movementData = movementData;
        this.inputController = inputController;
        movementData.SetJumpVariables();
    }

    public void PerformIdle()
    {
        physicsProcessor.StopMovement();
    }
    public void PerformWalk()
    {
        Vector3 direction = inputController.MovementDirection * Time.fixedDeltaTime;
        physicsProcessor.SetMovementDirection(direction);
    }
    public void PerformRun()
    {
        Vector3 direction = inputController.MovementDirection * movementData.RunningSpeed * Time.fixedDeltaTime;
        //Vector3 cameraRelatedVector = physicsProcessor.ConvertToCameraSpace(direction);
        physicsProcessor.SetMoveDirectionCameraBased(direction, ref turnSmoothVelocity, movementData.TurnSmoothTime, movementData.RunningSpeed);
    }

    public void PerformJump()
    {
        float verticalVelocity = physicsProcessor.VerticalVelocityVerletIntegration(physicsProcessor.GravityVector, movementData.InitialJumpVelocity);
        physicsProcessor.SetGravity(movementData.DownwardAcceleration);
        //physicsProcessor.SetJumpVector(movementData.DownwardAcceleration);
        physicsProcessor.ApplyVerticalForce(verticalVelocity);
    }


    public void PerormTargetLock()
    {

    }

}
