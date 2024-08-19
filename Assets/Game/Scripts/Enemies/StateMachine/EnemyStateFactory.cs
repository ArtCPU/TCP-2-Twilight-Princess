

using Game.Controller;
using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class EnemyStateFactory
    {
        private EnemyStateMachine enemyStateMachine;
        private EnemyController enemyController;

        public readonly BaseState Idle;
        public readonly BaseState Chase;
        public readonly BaseState Attack;
        public readonly BaseState Hurt;
        public readonly BaseState Death;

        public EnemyStateFactory (EnemyStateMachine enemyStateMachine, EnemyController enemyController)
        {
            this.enemyStateMachine = enemyStateMachine;
            this.enemyController = enemyController;

            Idle = new IdleState(this.enemyStateMachine, this.enemyController);
            Chase = new ChaseState(this.enemyStateMachine, this.enemyController);
            Attack = new AttackState(this.enemyStateMachine, this.enemyController);
            Hurt = new HurtState(this.enemyStateMachine, this.enemyController);
            Death = new DeathState(this.enemyStateMachine, this.enemyController);
        }
    }
}