using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class IdleState : BaseState
    {
        private EnemyController controller;
        public IdleState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            controller = currentCharacter.GetComponent<EnemyController>();
        }

        public override void Enter()
        {
            Debug.Log("Entered the ENEMY IDLE state");
        }

        public override void Exit()
        {
            Debug.Log("Exited the ENEMY IDLE state");
        }

        public override void FixedUpdate()
        {
            Debug.Log("aaaaaidou");
            if (controller.IsInSightRange())
            {
                controller.SetState(controller.stateMachine.StateFactory.Chase);
            }
        }

        public override void Update()
        {

        }
    }
}