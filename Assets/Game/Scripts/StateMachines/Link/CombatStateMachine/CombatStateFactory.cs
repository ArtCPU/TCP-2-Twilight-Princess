using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.State;
using UnityEngine;

public class CombatStateFactory : MonoBehaviour
{
    private StateMachine stateMachine;
    private CombatStateMachine combatStateMachine;
    private LinkController linkController;

    public readonly BaseState Attack1;
    public readonly BaseState Attack2;
    public readonly BaseState Attack3;
    public readonly BaseState Attack4;


    public CombatStateFactory(StateMachine stateMachine, CombatStateMachine combatStateMachine, LinkController linkController)
    {
        this.stateMachine = stateMachine;
        this.combatStateMachine = combatStateMachine;
        this.linkController = linkController;

        Attack1 = new Attack1State(this.stateMachine, this.combatStateMachine, this.linkController);
        Attack2 = new Attack2State(this.stateMachine, this.combatStateMachine, this.linkController);
        Attack3 = new Attack3State(this.stateMachine, this.combatStateMachine, this.linkController);
        Attack4 = new Attack4State(this.stateMachine, this.combatStateMachine, this.linkController);
    }
}
