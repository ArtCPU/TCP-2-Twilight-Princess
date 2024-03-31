using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class HurtState : BaseState
    {
        private EnemyController controller;
        public HurtState(StateMachine currentStateMachine, GameObject currentCharacter) : base(currentStateMachine, currentCharacter)
        {
            controller = currentCharacter.GetComponent<EnemyController>();
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }

        public override void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}