using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class ChaseState : BaseState
    {
        private EnemyController controller;
        public ChaseState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            controller = currentCharacter.GetComponent<EnemyController>();
        }

        public override void Enter()
        {
            Debug.Log("Entered the ENEMY CHASE state");
        }

        public override void Exit()
        {
            controller.Stop();
            Debug.Log("Exited the ENEMY CHASE state");
        }

        public override void FixedUpdate()
        {
            controller.ChaseTarget();

            if (controller.IsInAttackRange())
            {
                controller.SetState(controller.stateMachine.StateFactory.Attack);
            }

            if (!controller.IsInSightRange())
            {
                controller.SetState(controller.stateMachine.StateFactory.Idle);
            }
        }

        public override void Update()
        {

        }
    }
}