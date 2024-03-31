using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class AttackState : BaseState
    {
        private EnemyController controller;
        public AttackState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            controller = currentCharacter.GetComponent<EnemyController>();
        }

        public override void Enter()
        {
            controller.Attack();
        }

        public override void Exit()
        {
            Debug.Log("Exited the ENEMY ATTACK state");
        }

        public override void FixedUpdate()
        {
            if (!controller.IsInAttackRange())
            {
                controller.SetState(controller.stateMachine.PreviousState);
            }
            else
            {
                controller.AttackCooldown();
                controller.Attack();
            }
        }

        public override void Update()
        {

        }
    }
}