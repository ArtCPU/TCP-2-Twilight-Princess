namespace Game.State
{
    public class LinkStateMachine : StateMachine
    {
        public LinkStateFactory StateFactory { get; private set; }

        private void Awake()
        {
            StateFactory = new LinkStateFactory(this);
            CurrentState = StateFactory.Idle;
        }
    }
}