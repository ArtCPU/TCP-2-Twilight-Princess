using Game.Controller;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace Game.State
{
    public class JumpState : LinkBaseState
    {
        public JumpState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {
        }

        public override void Enter()
        {
            //Debug.Log("Entered the JUMP state");
            stateMachine.LinkController.AnimationController.PlayJump();
            linkController.LinkActions.PerformJump();
        }

        public override void Exit()
        {

        }

        public override void FixedUpdate()
        {
            //linkController.PhysicsProcessor.SetMovementDirection(linkController.InputController.MovementDirection * linkController.MovementData.WalkingSpeed * Time.fixedDeltaTime);
        }

        public override void Update()
        {
            stateMachine.TryPerformIdle();
            stateMachine.TryPerformWalk();
            stateMachine.TryPerformRun();
        }
    }
}