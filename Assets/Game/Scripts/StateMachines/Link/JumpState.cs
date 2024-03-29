using UnityEngine;
namespace Game.State
{
    public class JumpState : BaseState
    {
        public JumpState(StateMachine currentStateMachine) : base(currentStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered the JUMP state");
        }

        public override void Exit()
        {
            Debug.Log(" Exited the JUMP state");
        }

        public override void FixedUpdate()
        {
            Debug.Log("JUMP Fixed Update...");
        }

        public override void Update()
        {
            Debug.Log("JUMP Update...");
        }
    }
}