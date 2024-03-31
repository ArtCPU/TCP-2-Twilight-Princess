using Unity.VisualScripting;

namespace Game.State
{
    public class LinkStateMachine : StateMachine
    {
        public LinkStateFactory StateFactory { get; private set; }

        private void Awake()
        {
            StateFactory = new LinkStateFactory(this, this.gameObject);
            CurrentState = StateFactory.Idle;
        }
    }
}