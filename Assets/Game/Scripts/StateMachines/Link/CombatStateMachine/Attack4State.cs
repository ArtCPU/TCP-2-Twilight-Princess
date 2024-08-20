using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.State;
using UnityEngine;

public class Attack4State : CombatSubState
{
    public Attack4State(StateMachine currentStateMachine, CombatStateMachine combatStateMachine, LinkController linkController) : base(currentStateMachine, combatStateMachine, linkController)
    {

    }

    public override void Enter()
    {
        Debug.Log("Atk 4");
        linkController.PhysicsProcessor.StopMovement();
        linkController.AnimationController.PlayAttack4();
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
        base.Update();
    }
}