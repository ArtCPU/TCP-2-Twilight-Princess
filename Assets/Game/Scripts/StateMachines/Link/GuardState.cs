using Game.Controller;
using UnityEngine;

namespace Game.State
{
    public class GuardState : LinkBaseState
    {
        public GuardState(LinkStateMachine currentStateMachine, LinkController linkController) : base(currentStateMachine, linkController)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered the GUARD state");
            stateMachine.LinkController.AnimationController.PlayBlock();
        }

        public override void Exit()
        {

        }

        public override void FixedUpdate()
        {

        }

        public override void Update()
        {
            //stateMachine.TryPerformGuard();
        }
    }
}