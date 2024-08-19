using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.State;
using Game.Controller;

public class CombatState : LinkBaseState
{
    public CombatStateMachine CombatStateMachine { get; private set; }

    public CombatState(LinkStateMachine linkStateMachine, LinkController linkController) : base(linkStateMachine, linkController)
    {
        CombatStateMachine = new CombatStateMachine(linkStateMachine, linkController);
        CombatStateMachine.Awake();
    }

    public override void Enter()
    {
        CombatStateMachine.TryPerformAttack1();
    }

    public override void Exit()
    {
        //xamaStateMachine.Input.InputBuffer.ClearInputBuffer();
    }

    public override void FixedUpdate()
    {
        linkController.PhysicsProcessor.ResetHorizontalVelocity();
        CombatStateMachine.FixedUpdate();
    }

    public override void Update()
    {
        CombatStateMachine.Update();
    }


}
