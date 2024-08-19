using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using Game;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField] private TagTarget taget;
    public Collider Collider { get; private set; }
    public HitController HitController { get; private set; }

    private void Start()
    {
        HitController = GetComponentInParent<ICharacterController>().HitController;
        Collider = GetComponent<Collider>();
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.IsTargetTag(taget)) return;
        IHit.TryHit(collider, HitController);
    }
    public void Activate(bool activate)
    {
        Collider.enabled = activate;
    }
}

[System.Flags]
public enum TagTarget
{
    Player = 1,
    Enemy = 2,
}
