using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour, IHitReceiver
{
    public event Action<HitController> Hit;
    public Collider HitCollider { get; private set; }

    private void Awake()
    {
        HitCollider = GetComponent<Collider>();
        HitCollider.isTrigger = true;
    }
    public void Activate(bool value)
    {
        HitCollider.enabled = value;
    }

    public void StartHit(HitController hitController)
    {
        Hit?.Invoke(hitController); 
    }
}
