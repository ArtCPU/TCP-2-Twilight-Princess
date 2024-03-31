using UnityEngine;

namespace Game.State
{
    public abstract class StateMachine : MonoBehaviour
    {
        public BaseState CurrentState { get; protected set; }
        public BaseState PreviousState { get; protected set; }
        private void Update()
        {
            CurrentState.Update();
        }

        private void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }

        public void SetState(BaseState state)
        {
            PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
