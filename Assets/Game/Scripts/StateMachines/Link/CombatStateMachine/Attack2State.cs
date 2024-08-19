using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.State;
using UnityEngine;

public class Attack2State : CombatSubState
{
    public Attack2State(StateMachine currentStateMachine, CombatStateMachine combatStateMachine, LinkController linkController) : base(currentStateMachine, combatStateMachine, linkController)
    {

    }

    public override void Enter()
    {
        Debug.Log("Atk 2");

        linkController.AnimationController.PlayAttack2();
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
        if (combatStateMachine.AnimationPastFrame(LinkAnimationHashs.Attack2, linkController.CombatData))
        {
            combatStateMachine.TryPerformAttack3();
        }

        base.Update();
    }
}