using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterData/Link/Combat Data")]
public class LinkCombatData : ScriptableObject, ICombatData
{
    [field: SerializeField] public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }
    [field: SerializeField] public int Attack { get; private set; }
    [field: SerializeField] public int Defense { get; private set; }
    [field: SerializeField] public int FrameTransition { get; private set; }

    public void Initialize()
    {
        CurrentHP = MaxHP;
    }

    public void IncreaseHP(int amount)
    {
        CurrentHP += amount;

        if (CurrentHP > MaxHP) CurrentHP = MaxHP;
    }
    public void DecreaseHP(int amount)
    {
        CurrentHP -= amount;

        if (CurrentHP < 0) CurrentHP = 0;
    }
}
