using Game.Controller;
using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class IdleState : EnemyBaseState
    {
        public IdleState(EnemyStateMachine currentStateMachine, EnemyController enemyController) : base(currentStateMachine, enemyController)
        {
        }

        public override void Enter()
        {
            enemyController.Stop();
            enemyController.AnimationContrller.PlayIdle();
        }

        public override void Exit()
        {

        }

        public override void FixedUpdate()
        {
            
        }

        public override void Update()
        {
            stateMachine.TryPerformChase();
            stateMachine.TryPerformAttack();
            stateMachine.TryPerformDeath();
        }
    }
}