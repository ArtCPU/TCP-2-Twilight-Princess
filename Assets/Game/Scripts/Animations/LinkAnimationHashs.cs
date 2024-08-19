using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LinkAnimationHashs 
{
    public static int Idle => Animator.StringToHash("Idle");
    public static int Walk => Animator.StringToHash("Walk");
    public static int Run =>  Animator.StringToHash("Run");
    public static int RunBackwards => Animator.StringToHash("RunBackwards");
    public static int StrafeFast => Animator.StringToHash("StrafeFast");
    public static int StrafeSlow => Animator.StringToHash("StrafeSlow");
    public static int Jump => Animator.StringToHash("Jump");
    public static int Block => Animator.StringToHash("Block");
    public static int Hurt => Animator.StringToHash("Hurt");
    public static int Death => Animator.StringToHash("Death");
    public static int Attack1 => Animator.StringToHash("Attack1");
    public static int Attack2 => Animator.StringToHash("Attack2");
    public static int Attack3 => Animator.StringToHash("Attack3");
    public static int Attack4 => Animator.StringToHash("Attack4");
}
