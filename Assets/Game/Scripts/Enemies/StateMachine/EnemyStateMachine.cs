using Game.Controller;
using Game.State;

namespace Game.States.Enemy
{
    public class EnemyStateMachine : StateMachine
    {
        public EnemyStateFactory StateFactory { get; private set; }
        public EnemyController EnemyController { get; private set; }
        private HitReceiver hitReceiver;

        private void Awake()
        {
            EnemyController = GetComponent<EnemyController>();
            StateFactory = new EnemyStateFactory(this, EnemyController);
            CurrentState = StateFactory.Idle;
            hitReceiver = GetComponentInChildren<HitReceiver>();
        }

        private void OnEnable()
        {
            hitReceiver.Hit += OnHit;
        }
        public void TryPerformIdle()
        {
            if(!EnemyController.IsInSightRange())
            {
                SetState(StateFactory.Idle);
            }
        }
        public void TryPerformChase()
        {
            if(!EnemyController.IsInAttackRange() && EnemyController.IsInSightRange())
            {
                SetState(StateFactory.Chase);
            }
        }
        public void TryPerformAttack()
        {
            if(EnemyController.IsInAttackRange())
            {
                SetState(StateFactory.Attack);
            }
        }
        public void OnHit(HitController hitController)
        {
            SetState(StateFactory.Hurt);
            EnemyController.CombatData.DecreaseHP(hitController.AttackerCombatData.Attack);
        }
        public void TryPerformDeath()
        {
            if (EnemyController.CombatData.CurrentHP <=0)
            {
                SetState(StateFactory.Death);
            }
        }

        private void OnDisable()
        {
            hitReceiver.Hit -= OnHit;
        }
    }
}