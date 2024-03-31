using Game.State;

namespace Game.States.Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public EnemyStateFactory StateFactory { get; private set; }

        private void Awake()
        {
            StateFactory = new EnemyStateFactory(this, this.gameObject);
            CurrentState = StateFactory.Idle;
        }
    }
}