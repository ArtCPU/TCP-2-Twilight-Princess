using UnityEngine;

namespace Game.State
{
    public abstract class StateMachine : MonoBehaviour
    {
        public BaseState CurrentState { get; protected set; }
        public BaseState PreviousState { get; protected set; }
        public void Update()
        {
            CurrentState.Update();
        }

        public void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }

        public void SetState(BaseState state)
        {
            if (state != CurrentState) PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
