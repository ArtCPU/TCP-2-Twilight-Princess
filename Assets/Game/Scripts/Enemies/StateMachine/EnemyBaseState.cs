using Game.Controller;
using Game.States.Enemy;

namespace Game.State
{
    public abstract class EnemyBaseState : BaseState
    {
        protected EnemyController enemyController;
        protected new EnemyStateMachine stateMachine;
        public EnemyBaseState(EnemyStateMachine currentStateMachine, EnemyController enemyController) : base(currentStateMachine)
        {
            this.enemyController = enemyController;
            stateMachine = currentStateMachine;
        }
    }
}
