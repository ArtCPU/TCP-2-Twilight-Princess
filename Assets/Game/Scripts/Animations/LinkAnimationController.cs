using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnimationController : MonoBehaviour
{
    [field : SerializeField] public Animator Animator {  get; private set; }

    public void PlayIdle()
    {
        Animator.CrossFade(LinkAnimationHashs.Idle, 0.1f);
    }

    public void PlayWalk()
    {
        Animator.CrossFade(LinkAnimationHashs.Walk, 0.3f);
    }

    public void PlayRun()
    {
        Animator.CrossFade(LinkAnimationHashs.Run, 0.1f);
    }

    public void PlayRunBackwards()
    {
        Animator.Play(LinkAnimationHashs.RunBackwards);
    }

    public void PlayStrafeFast()
    {
        Animator.Play(LinkAnimationHashs.StrafeFast);
    }

    public void PlayStrafeSlow()
    {
        Animator.Play(LinkAnimationHashs.StrafeSlow);
    }

    public void PlayJump()
    {
        Animator.CrossFade(LinkAnimationHashs.Jump, 0.3f);
    }

    public void PlayBlock()
    {
        Animator.Play(LinkAnimationHashs.Block);
    }

    public void PlayHurt()
    {
        Animator.CrossFade(LinkAnimationHashs.Hurt, 0.3f);
    }

    public void PlayDeath()
    {
        Animator.CrossFade(LinkAnimationHashs.Death, 0.3f);
    }

    public void PlayAttack1()
    {
        Animator.CrossFade(LinkAnimationHashs.Attack1, 0.3f);
    } 

    public void PlayAttack2()
    {
        Animator.CrossFade(LinkAnimationHashs.Attack2, 0.3f);
    }

    public void PlayAttack3()
    {
        Animator.CrossFade(LinkAnimationHashs.Attack3, 0.3f);
    }

    public void PlayAttack4()
    {
        Animator.CrossFade(LinkAnimationHashs.Attack4, 0.3f);
    }
}
