using Game.Controller;
using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class AttackState : EnemyBaseState
    {
        private float registeredTime = 0f;
        public AttackState(EnemyStateMachine currentStateMachine, EnemyController enemyController) : base(currentStateMachine, enemyController)
        {

        }

        public override void Enter()
        {
            enemyController.SetSightRange(enemyController.MovementData.OnChaseSightRange);
            enemyController.AnimationContrller.PlayAttack();
            enemyController.Stop();
        }

        public override void Exit()
        {
            registeredTime = 0f;
        }

        public override void FixedUpdate()
        {

        }

        public override void Update()
        {
            registeredTime += Time.deltaTime;
            if (registeredTime >= enemyController.CombatData.AttackCooldown && enemyController.AnimationContrller.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                stateMachine.TryPerformChase();
                stateMachine.TryPerformIdle();
                stateMachine.TryPerformDeath();
                stateMachine.TryPerformAttack();
            }
        }
    }
}