using Game.Controller;
using UnityEngine;
using Game.State;

public class Attack1State : CombatSubState
{
    public Attack1State(StateMachine currentStateMachine, CombatStateMachine combatStateMachine, LinkController linkController) : base(currentStateMachine, combatStateMachine, linkController)
    {
    }

    public override void Enter()
    {
        Debug.Log("Atk 1");
        linkController.AnimationController.PlayAttack1();
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
        if (combatStateMachine.AnimationPastFrame(LinkAnimationHashs.Attack1, linkController.CombatData))
        {
            combatStateMachine.TryPerformAttack2();
        }

        base.Update();
    }
}

