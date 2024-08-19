using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterData/Enemy/Movement Data")]
public class EnemyMovementData : ScriptableObject
{
    [field:SerializeField] public float MovementSpeed {  get; private set; }
    [field:SerializeField] public float SightRange { get; private set; }
    [field:SerializeField] public float OnChaseSightRange { get; private set; }
}
