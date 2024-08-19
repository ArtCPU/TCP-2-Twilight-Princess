using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Game.States.Enemy;
using Game.State;
namespace Game.Controller
{
    public class EnemyController : MonoBehaviour, ICharacterController
    {
        public GameObject Target { get; private set; }
        public EnemyAnimationController AnimationContrller { get; private set; }
        public HitController HitController { get; private set; }
        [field: SerializeField] public EnemyMovementData MovementData { get; private set; }
        [field: SerializeField] public EnemyCombatData CombatData { get; private set; }

        [SerializeField] private LayerMask targetLayer;

        private NavMeshAgent agent;
        private Coroutine coroutine;
        private float currentSightRange;

        private void Awake()
        {
            CombatData = Instantiate(CombatData);
            CombatData.Initialize();
            HitController = new HitController(CombatData);
        }
        private void Start()
        {
            Target = PlayerManager.Instance.Player;
            agent = GetComponent<NavMeshAgent>();
            AnimationContrller = GetComponent<EnemyAnimationController>();
            agent.speed = MovementData.MovementSpeed;
            currentSightRange = MovementData.SightRange;
        }

        public bool IsInSightRange()
        {
            return Physics.CheckSphere(transform.position, currentSightRange, targetLayer);
        }

        public bool IsInAttackRange()
        {
            return Physics.CheckSphere(transform.position, CombatData.AttackRange, targetLayer);
        }
        public void PerformChase()
        {
            agent.SetDestination(Target.transform.position);
        }

        public void PerformAttack()
        {
            coroutine = StartCoroutine(Attack());
        }

        public void CancelAttack()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
        private IEnumerator Attack()
        {
            Stop();
            yield return new WaitForSeconds(CombatData.AttackCooldown);
            StartCoroutine(Attack());
        }
        public void Stop()
        {
            agent.SetDestination(transform.position);
        }

        public void SetSightRange(float range)
        {
            currentSightRange = range;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, MovementData.SightRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, CombatData.AttackRange);
        }


    }

}

