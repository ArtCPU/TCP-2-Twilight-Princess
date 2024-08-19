using Game.Controller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.State
{
    public class RunState : LinkBaseState
    {
        public RunState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {

        }

        public override void Enter()
        {
            //Debug.Log("Entered the RUN state");
            stateMachine.LinkController.AnimationController.PlayRun();
        }

        public override void Exit()
        {

        }

        public override void FixedUpdate()
        {
            //linkController.UpdateMoveDirection(stateMachine.LinkInputController.MoveDirection.normalized);
            linkController.LinkActions.PerformRun();
        }

        public override void Update()
        {
            stateMachine.TryPerformJump();
            stateMachine.TryPerformWalk();
            stateMachine.TryPerformIdle();
            stateMachine.TryPerformCombat();
            //stateMachine.TryPerformGuard();
            stateMachine.TryPerformDeath();
            stateMachine.TryPerformAim();
        }


            
    }
}