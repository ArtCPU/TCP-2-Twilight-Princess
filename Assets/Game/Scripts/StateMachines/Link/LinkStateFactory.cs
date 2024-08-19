namespace Game.State
{
    using Game.Controller;
    public class LinkStateFactory
    {
        private LinkController linkController;
        private LinkStateMachine linkStateMachine;

        public readonly BaseState Idle;
        public readonly BaseState Walk;
        public readonly BaseState Run;
        public readonly BaseState Jump;
        public readonly BaseState CombatState;
        public readonly BaseState Guard;
        public readonly BaseState TargetLock;
        public readonly BaseState Hurt;
        public readonly BaseState Aim;
        public readonly BaseState Death;

        public LinkStateFactory(LinkController linkController, LinkStateMachine linkStateMachine )
        {
            this.linkController = linkController;
            this.linkStateMachine = linkStateMachine;
            Idle = new IdleState(this.linkStateMachine, this.linkController);
            Jump = new JumpState(this.linkStateMachine, this.linkController);
            Walk = new WalkState(this.linkStateMachine, this.linkController);
            Run = new RunState(this.linkStateMachine, this.linkController);
            CombatState = new CombatState(this.linkStateMachine, this.linkController);
            Guard = new GuardState(this.linkStateMachine, this.linkController);
            TargetLock = new TargetLockState(this.linkStateMachine, this.linkController);
            Hurt = new HurtState(this.linkStateMachine, this.linkController);
            Aim = new AimState(this.linkStateMachine, this.linkController);
            Death = new DeathState(this.linkStateMachine, this.linkController);
        }
    }
}