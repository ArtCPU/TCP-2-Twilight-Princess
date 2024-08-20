using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [field: SerializeField] public Animator Animator {  get; private set; }

    public void PlayIdle()
    {
        Animator.Play(EnemyAnimationHashs.Idle);
    }

    public void PlayRun()
    {
        Animator.Play(EnemyAnimationHashs.Run);
    }

    public void PlayAttack()
    {
        Animator.ForceStateNormalizedTime(0);
        Animator.Play(EnemyAnimationHashs.Attack);
    }

    public void PlayInitialized()
    {
        Animator.Play(EnemyAnimationHashs.Initialized);
    }

    public void PlayHurt()
    {
        Animator.Play(EnemyAnimationHashs.Hurt);
    }

    public void PlayDeath()
    {
        Animator.Play(EnemyAnimationHashs.Death);
    }
}
