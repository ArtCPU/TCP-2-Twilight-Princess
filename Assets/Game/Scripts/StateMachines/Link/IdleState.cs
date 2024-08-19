using Game.Controller;
using UnityEngine;
namespace Game.State
{
    public class IdleState : LinkBaseState
    {
        public IdleState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        
        {

        }

        public override void Enter()
        {
            stateMachine.LinkController.AnimationController.PlayIdle();
        }

        public override void Exit()
        {

        }

        public override void FixedUpdate()
        {
            linkController.LinkActions.PerformIdle();
        }
        public override void Update()
        {
            stateMachine.TryPerformWalk();
            stateMachine.TryPerformRun();
            stateMachine.TryPerformJump();
            stateMachine.TryPerformCombat();
            //stateMachine.TryPerformGuard();
            stateMachine.TryPerformAim();
            stateMachine.TryPerformTargetLock();
            stateMachine.TryPerformDeath();
        }
    }
}