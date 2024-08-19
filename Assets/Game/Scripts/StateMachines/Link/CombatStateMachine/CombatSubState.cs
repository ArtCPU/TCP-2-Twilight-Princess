using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.State;
using UnityEngine;

public abstract class CombatSubState : BaseState
{
    protected LinkController linkController;
    protected CombatStateMachine combatStateMachine;
    protected LinkCombatData combatData;

    float releaseTime = 0;

    protected CombatSubState(StateMachine currentStateMachine, CombatStateMachine combatStateMachine, LinkController linkController) : base(currentStateMachine)
    {
        this.combatStateMachine = combatStateMachine;
        this.linkController = linkController;
        combatData = linkController.CombatData;
    }

    public override void Enter()
    {
        releaseTime = 0;
    }
    public override void Update()
    {
        TryFinalizeState();
    }
    public void TryFinalizeState()
    {
        LinkAnimationController animationController = linkController.AnimationController;
        releaseTime += Time.deltaTime;
        if (releaseTime < 0.3f) return;
        if (animationController.Animator.GetNormalizedTime() > 1)
        {
            combatStateMachine.FinalizeCombatState();
        }
    }

}
