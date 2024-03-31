using System;
using Game;
using Game.State;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        Instance = this;
    }

    public event Action<Targetable> OnTargetView;
    public event Action<Targetable> OnTargetLock;
    public event Action<Targetable> OnTargetDeview;
    public event Action<Targetable> OnTargetRelease;
    public event Action<int> OnDamage;

    public void TargetView(Targetable target)
    {
        OnTargetView?.Invoke(target);
    }

    public void TargetLock(Targetable target)
    {
        OnTargetLock?.Invoke(target);
    }

    public void TargetRelease(Targetable target)
    {
        OnTargetRelease.Invoke(target);
    }

    public void TargetUnview(Targetable target)
    {
        OnTargetDeview?.Invoke(target);
    }
    public void Damage(int amount)
    {
        OnDamage?.Invoke(amount);
    }

}