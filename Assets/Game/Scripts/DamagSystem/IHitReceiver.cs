using System;


public interface IHitReceiver
{
    public event Action<HitController> Hit;
    void Activate(bool value);
    void StartHit(HitController hitAction);
}