using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterData/Link/Movement Data")]
public class LinkMovementData : ScriptableObject
{
    [field: Header("Movement Settings")]
    [field: SerializeField] public float WalkingSpeed { get; private set; } = 10f;
    [field: SerializeField] public float RunningSpeed { get; private set; } = 20f;
    [field: SerializeField] public float TurnSmoothTime { get; private set; } = 0.1f;

    [field: Header("Jump Settings")]
    [field: SerializeField] public float MaxJumpHeight { get; private set; } = 1.0f;
    [field: SerializeField] public float MaxJumpTime { get; private set; } = 0.5f;
    public float InitialJumpVelocity { get; private set; }
    public float DownwardAcceleration { get; private set; }

    public void SetJumpVariables()
    {
        float timeToMaxHeight = MaxJumpTime / 2;
        DownwardAcceleration = (-2 * MaxJumpHeight) / Mathf.Pow(timeToMaxHeight, 2);
        InitialJumpVelocity = (2 * MaxJumpHeight) / timeToMaxHeight;
    }
}
