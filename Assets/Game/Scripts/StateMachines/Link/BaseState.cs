using UnityEngine;

namespace Game.State
{
    public abstract class BaseState
    {
        protected StateMachine stateMachine;
        protected BaseState(StateMachine currentStateMachine)
        {
            stateMachine = currentStateMachine;
        }
        public abstract void Enter();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void Exit();
    }

}