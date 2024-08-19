using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.State;
using UnityEngine;

public class CombatStateMachine : StateMachine
{
    public CombatStateFactory CombatStateFactory { get; private set; }
    public LinkStateMachine LinkStateMachine { get; private set; }

    private LinkController linkController;
    //private InputBuffer inputBuffer;
    public void Awake()
    {
        CurrentState = CombatStateFactory.Attack1;

    }

    public CombatStateMachine(LinkStateMachine linkStateMachine, LinkController xamaController)
    {
        this.LinkStateMachine = linkStateMachine;
        this.linkController = xamaController;
        //inputBuffer = linkStateMachine.Input.InputBuffer;
        CombatStateFactory = new CombatStateFactory(this, this, xamaController);
    }
    //
    public void FinalizeCombatState()
    {
        // Debug.Log("finalize combat state");
        LinkStateMachine.SetState(LinkStateMachine.StateFactory.Idle);
    }
    //


    public void TryPerformAttack1()
    {
        if (linkController.InputController.Attack.WasPressedThisFrame())
        {
            //linkStateMachine.Input.InputBuffer.RemoveBufferedInput();
            SetState(CombatStateFactory.Attack1);
        }
    }
    public void TryPerformAttack2()
    {
        if (linkController.InputController.Attack.WasPressedThisFrame())
        {
            //linkStateMachine.Input.InputBuffer.RemoveBufferedInput();
            SetState(CombatStateFactory.Attack2);
        }
    }

    public void TryPerformAttack3()
    {
        if (linkController.InputController.Attack.WasPressedThisFrame())
        {
            //linkStateMachine.Input.InputBuffer.RemoveBufferedInput();
            SetState(CombatStateFactory.Attack3);
        }
    } 
    public void TryPerformAttack4()
    {
        if (linkController.InputController.Attack.WasPressedThisFrame())
        {
            //linkStateMachine.Input.InputBuffer.RemoveBufferedInput();
            SetState(CombatStateFactory.Attack4);
        }
    }

    //public void TryDelayFall()
    //{
    //    if (linkStateMachine.PreviousState is JumpState)
    //    {
    //        linkController.PhysicsProcessor.ResetHorizontalVelocity();
    //        linkController.PhysicsProcessor.ResetVerticalVelocity();
    //    }
    //}
    public bool AnimationPastFrame(int animationHash, LinkCombatData combatData)
    {
        return linkController.AnimationController.Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animationHash &&
               linkController.AnimationController.Animator.GetCurrentFrame() >= combatData.FrameTransition;
    }
    public bool AnimationPastFrame(int animationHash, int frame)
    {
        return linkController.AnimationController.Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animationHash && linkController.AnimationController.Animator.GetCurrentFrame() > frame;
    }

    public bool AnimationBeforeFrame(int animationHash, int frame)
    {
        return linkController.AnimationController.Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animationHash && linkController.AnimationController.Animator.GetCurrentFrame() < frame;
    }


}
