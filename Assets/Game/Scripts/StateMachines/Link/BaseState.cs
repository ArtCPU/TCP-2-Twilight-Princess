using UnityEngine;

namespace Game.State
{
    public abstract class BaseState
    {
        protected StateMachine stateMachine;
        protected GameObject character;
        protected BaseState(StateMachine currentStateMachine, GameObject currentCharacter)
        {
            stateMachine = currentStateMachine;
            character = currentCharacter;
        }
        public abstract void Enter();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void Exit();
    }
}