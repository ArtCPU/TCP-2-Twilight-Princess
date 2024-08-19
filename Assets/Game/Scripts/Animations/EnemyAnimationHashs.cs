using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAnimationHashs 
{
    public static int Idle => Animator.StringToHash("Idle");
    public static int Attack => Animator.StringToHash("Attack");
    public static int Hurt => Animator.StringToHash("Hurt");
    public static int Run => Animator.StringToHash("Run");
    public static int Initialized => Animator.StringToHash("Initialized");
    public static int Death => Animator.StringToHash("Death");
}
