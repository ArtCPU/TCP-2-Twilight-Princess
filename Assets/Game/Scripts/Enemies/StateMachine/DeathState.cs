using Game.Controller;
using Game.State;
using UnityEngine;

namespace Game.States.Enemy
{
    public class DeathState : EnemyBaseState
    {
        public DeathState(EnemyStateMachine currentStateMachine, EnemyController enemyController) : base(currentStateMachine, enemyController)
        {
        }

        public override void Enter()
        {
            Debug.Log("Entered the DEATH state");
        }

        public override void Exit()
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void Update()
        {
        }
    }
}