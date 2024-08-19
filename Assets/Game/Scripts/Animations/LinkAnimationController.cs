using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnimationController : MonoBehaviour
{
    [field : SerializeField] public Animator Animator {  get; private set; }

    public void PlayIdle()
    {
        Animator.Play(LinkAnimationHashs.Idle);
    }

    public void PlayWalk()
    {
        Animator.Play(LinkAnimationHashs.Walk);
    }

    public void PlayRun()
    {
        Animator.Play(LinkAnimationHashs.Run);
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
        Animator.Play(LinkAnimationHashs.Jump);
    }

    public void PlayBlock()
    {
        Animator.Play(LinkAnimationHashs.Block);
    }

    public void PlayHurt()
    {
        Animator.Play(LinkAnimationHashs.Hurt);
    }

    public void PlayDeath()
    {
        Animator.Play(LinkAnimationHashs.Death);
    }

    public void PlayAttack1()
    {
        Animator.Play(LinkAnimationHashs.Attack1);
    } 

    public void PlayAttack2()
    {
        Animator.Play(LinkAnimationHashs.Attack2);
    }

    public void PlayAttack3()
    {
        Animator.Play(LinkAnimationHashs.Attack3);
    }

    public void PlayAttack4()
    {
        Animator.Play(LinkAnimationHashs.Attack4);
    }
}
