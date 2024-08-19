using Game.Controller;
using UnityEngine;

namespace Game.State
{
    public class HurtState : LinkBaseState
    {
        public HurtState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {
        }

        public override void Enter()
        {
            linkController.AnimationController.PlayHurt();
            linkController.PhysicsProcessor.StopMovement();
        }

        public override void Exit()
        {
           
        }

        public override void FixedUpdate()
        {
        }
        public override void Update()
        {
            if (linkController.AnimationController.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                stateMachine.SetState(stateMachine.PreviousState);
            }
        }
    }
}