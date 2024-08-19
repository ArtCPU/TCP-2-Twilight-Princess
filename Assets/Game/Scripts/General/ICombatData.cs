using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatData  
{
    public int MaxHP { get;}
    public int CurrentHP { get;}
    public int Attack { get;}
    public int Defense { get;}

    public void Initialize();
    public void IncreaseHP(int amount);
    public void DecreaseHP(int amount);
}
