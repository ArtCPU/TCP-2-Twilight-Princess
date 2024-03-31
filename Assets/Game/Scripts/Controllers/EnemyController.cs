using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Game.States.Enemy;
using Unity.VisualScripting;
using Game.State;

[RequireComponent(typeof(EnemyStateMachine))]
public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    private GameObject target;
    private NavMeshAgent agent;
    [SerializeField] private LayerMask targetLayer;

    [Header("Control Variables")]
    [SerializeField] private float sightRange, attackRange, attackCooldown;

    private void Start()
    {
        target = PlayerManager.Instance.Player;
        agent = GetComponent<NavMeshAgent>();
        stateMachine = GetComponent<EnemyStateMachine>();
    }
    
    public bool IsInSightRange()
    {
        return Physics.CheckSphere(transform.position, sightRange, targetLayer);
    }

    public bool IsInAttackRange()
    {
        return Physics.CheckSphere(transform.position, attackRange, targetLayer);
    }
    public void ChaseTarget()
    {
        agent.SetDestination(target.transform.position);
    }

    public void Attack()
    {
        Debug.Log("The Enemy Attacked You!");
    }

    public void AttackCooldown()
    {
        StartCoroutine(Cooldown());
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
    }

    public void SetState(BaseState state)
    {
        stateMachine.SetState(state);
    }

    public void Stop()
    {
        agent.SetDestination(transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
