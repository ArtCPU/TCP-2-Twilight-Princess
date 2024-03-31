using UnityEngine;

namespace Game.State
{
    public class LinkStateFactory
    {
        private StateMachine stateMachine;
        private GameObject character;

        public readonly BaseState Idle;
        public readonly BaseState Walk;
        public readonly BaseState Run;
        public readonly BaseState Jump;
        public readonly BaseState Attack;
        public readonly BaseState Defend;
        public readonly BaseState TargetLock;
        public readonly BaseState Hurt;
        public readonly BaseState Aim;
        public readonly BaseState Death;

        public LinkStateFactory(StateMachine currentStateMachine, GameObject currentCharacter)
        {
            stateMachine = currentStateMachine;
            character = currentCharacter;
            Idle = new IdleState(stateMachine, character);
            Walk = new WalkState(stateMachine, character);
            Run = new RunState(stateMachine, character);
            Jump = new JumpState(stateMachine, character);
            Attack = new AttackState(stateMachine, character);
            Defend = new DefendState(stateMachine, character);
            TargetLock = new TargetLockState(stateMachine, character);
            Hurt = new HurtState(stateMachine, character);
            Aim = new AimState(stateMachine, character);
            Death = new DeathState(stateMachine, character);
        }
    }
}