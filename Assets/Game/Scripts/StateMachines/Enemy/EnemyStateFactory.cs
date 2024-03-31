

using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class EnemyStateFactory
    {
        private StateMachine stateMachine;
        private GameObject character;

        public readonly BaseState Idle;
        public readonly BaseState Chase;
        public readonly BaseState Attack;
        public readonly BaseState Hurt;
        public readonly BaseState Death;

        public EnemyStateFactory (StateMachine currentStateMachine, GameObject currentCharacter)
        {
            stateMachine = currentStateMachine;
            character = currentCharacter;

            Idle = new IdleState(stateMachine, character);
            Chase = new ChaseState(stateMachine, character);
            Attack = new AttackState(stateMachine, character);
            Hurt = new HurtState(stateMachine, character);
            Death = new DeathState(stateMachine, character);
        }
    }
}