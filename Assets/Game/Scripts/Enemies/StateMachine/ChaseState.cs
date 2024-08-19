using Game.Controller;
using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class ChaseState : EnemyBaseState
    {
        public ChaseState(EnemyStateMachine currentStateMachine, EnemyController enemyController) : base(currentStateMachine, enemyController)
        {

        }

        public override void Enter()
        {
            enemyController.SetSightRange(enemyController.MovementData.OnChaseSightRange);
            enemyController.AnimationContrller.PlayRun();
        }

        public override void Exit()
        {
            enemyController.SetSightRange(enemyController.MovementData.SightRange);
        }

        public override void FixedUpdate()
        {
            enemyController.PerformChase();
        }

        public override void Update()
        {
            stateMachine.TryPerformAttack();
            stateMachine.TryPerformIdle();
            stateMachine.TryPerformDeath();
        }
    }
}