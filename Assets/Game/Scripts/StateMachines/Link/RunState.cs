using UnityEngine;
namespace Game.State
{
    public class RunState : BaseState
    {
        public RunState(StateMachine currentStateMachine) : base(currentStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered the RUN state");
        }

        public override void Exit()
        {
            Debug.Log("Exited the RUN state");
        }

        public override void FixedUpdate()
        {
            Debug.Log("RUN Fixed Update...");
        }

        public override void Update()
        {
            Debug.Log("RUN Update...");
        }
    }
}