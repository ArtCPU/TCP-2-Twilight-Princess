using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.State;
using UnityEngine;

public class Attack3State : CombatSubState
{
    public Attack3State(StateMachine currentStateMachine, CombatStateMachine combatStateMachine, LinkController linkController) : base(currentStateMachine, combatStateMachine, linkController)
    {

    }

    public override void Enter()
    {
        Debug.Log("Atk 3");
        linkController.PhysicsProcessor.StopMovement();
        linkController.AnimationController.PlayAttack3();
        base.Enter();
    }

    public override void Exit()
    {

    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {
        //if (combatStateMachine.AnimationPastFrame(LinkAnimationHashs.Attack3, linkController.CombatData))
        //{
        //    combatStateMachine.TryPerformAttack4();
        //}

        base.Update();
    }
}