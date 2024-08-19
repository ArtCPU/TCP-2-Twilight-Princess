using Game.Controller;
using UnityEngine;

namespace Game.State
{
    public class WalkState : LinkBaseState
    {
        public WalkState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered the WALK state");
            stateMachine.LinkController.AnimationController.PlayWalk();
        }

        public override void Exit()
        {
        }

        public override void FixedUpdate()
        {
            //linkController.UpdateMoveDirection(stateMachine.LinkInputController.MoveDirection.normalized);
            linkController.LinkActions.PerformWalk();
        }

        public override void Update()
        {
            stateMachine.TryPerformJump();
            stateMachine.TryPerformRun();
            stateMachine.TryPerformIdle();
            stateMachine.TryPerformCombat();
            //stateMachine.TryPerformGuard();
            stateMachine.TryPerformDeath();
            stateMachine.TryPerformAim();
        }
    }
}