namespace Game.State
{
    public class LinkStateFactory
    {
        private StateMachine stateMachine;

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

        public LinkStateFactory(StateMachine currentStateMachine)
        {
            stateMachine = currentStateMachine;
            Idle = new IdleState(stateMachine);
            Walk = new WalkState(stateMachine);
            Run = new RunState(stateMachine);
            Jump = new JumpState(stateMachine);
            Attack = new AttackState(stateMachine);
            Defend = new DefendState(stateMachine);
            TargetLock = new TargetLockState(stateMachine);
            Hurt = new HurtState(stateMachine);
            Aim = new AimState(stateMachine);
            Death = new DeathState(stateMachine);
        }
    }
}