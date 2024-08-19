using Game.Controller;
using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class HurtState : EnemyBaseState
    {
        public HurtState(EnemyStateMachine currentStateMachine, EnemyController enemyController) : base(currentStateMachine, enemyController)
        {

        }

        public override void Enter()
        {
            enemyController.AnimationContrller.PlayHurt();
            enemyController.Stop();
        }

        public override void Exit()
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void Update()
        {
            if (enemyController.AnimationContrller.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >=1)
            {
                stateMachine.SetState(stateMachine.PreviousState);
            }
        }
    }
}