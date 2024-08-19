using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController
{
    public ICombatData AttackerCombatData { get; private set; }
    public HitController(ICombatData attackerCombatData)
    {
        AttackerCombatData = attackerCombatData;
    }
}
