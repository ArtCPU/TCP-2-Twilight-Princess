using UnityEngine;
namespace Game.State
{
    public class IdleState : BaseState
    {
        public IdleState(StateMachine currentStateMachine) : base(currentStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered the IDLE state");
        }

        public override void Exit()
        {
            Debug.Log("Exited the IDLE state");
        }

        public override void FixedUpdate()
        {
            Debug.Log("IDLE Fixed Update...");
        }

        public override void Update()
        {
            Debug.Log("IDLE Update...");
        }
    }
}