using Game.Controller;
using UnityEngine;

namespace Game.State
{
    public class DeathState : LinkBaseState
    {
        public DeathState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {
        }

        public override void Enter()
        {
            Debug.Log("You Died!");
            stateMachine.LinkController.AnimationController.PlayDeath();
        }

        public override void Exit()
        {
        }

        public override void FixedUpdate()
        {
            //playerMovement.SetState(playerMovement.stateMachine.StateFactory.Idle);
        }

        public override void Update()
        {
            
        }
    }
}