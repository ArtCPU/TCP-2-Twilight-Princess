using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHit
{
    public static void TryHit(Collider collider, HitController hitController)
    {
        IHitReceiver receiver = null;
        if (!collider.gameObject.TryGetComponent(out receiver)) return;
        ApplyHit(receiver, hitController);
    }
    private static void ApplyHit(IHitReceiver receiver, HitController hitController)
    {
        receiver.StartHit(hitController);
    }
}
