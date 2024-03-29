using UnityEngine;
namespace Game.State
{
    public class TargetLockState : BaseState
    {
        public TargetLockState(StateMachine currentStateMachine) : base(currentStateMachine)
        {
        }
       
        public override void Enter()
        {
            Debug.Log("Entered the TARGET LOCK state");
        }

        public override void Exit()
        {
            Debug.Log("Exited the TARGET LOCK state");
        }

        public override void FixedUpdate()
        {
            Debug.Log("TARGET LOCK Fixed Update...");
        }

        public override void Update()
        {
            Debug.Log("TARGET LOCK Update...");
        }
    }
}