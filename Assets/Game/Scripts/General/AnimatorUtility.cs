using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorUtility
{
    public static float GetSpeedMultiplier(this Animator animator, int layerIndex = 0)
    {
        return animator.GetCurrentAnimatorStateInfo(layerIndex).speedMultiplier;

    }

    public static void SetSpeedMultiplier(this Animator animator, string parameterName, float speedMultiplier)
    {
        animator.SetFloat(Animator.StringToHash(parameterName), speedMultiplier);
    }


    /// <summary>
    /// Return animation time percentage (beetween 0 and 1).
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="layerIndex"></param>
    /// <returns></returns>
    public static float GetNormalizedTime(this Animator animator, int layerIndex = 0)
    {

        return animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime;
    }

    public static int GetStateHash(this Animator animator, int layer = 0)
    {
        return animator.GetCurrentAnimatorStateInfo(layer).shortNameHash;
    }

    public static int GetFrameCount(this Animator animator, int layerIndex = 0)
    {
        AnimationClip clip = animator.GetCurrentClip();
        return Mathf.FloorToInt(clip.length * clip.frameRate);
    }
    public static float GetFrameDuration(this Animator animator, int layerIndex = 0)
    {
        return animator.GetAnimationDuration(layerIndex) / animator.GetFrameCount(layerIndex);
    }

    public static float GetAnimationDuration(this Animator animator, int layerIndex = 0)
    {
        return animator.GetCurrentClip(layerIndex).length;
    }
    public static AnimationClip GetCurrentClip(this Animator animator, int layerIndex = 0)
    {
        if (animator.GetCurrentAnimatorClipInfoCount(0) == 0) return new AnimationClip();
        return animator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip;
    }


    public static int GetCurrentFrame(this Animator animator, int layerIndex = 0)
    {
        return (int)(GetNormalizedTime(animator, layerIndex) * GetFrameCount(animator, layerIndex)) % GetFrameCount(animator, layerIndex) + 1;
    }

    public static bool IsFrameEqual(this Animator animator, int frame, int layerIndex = 0)
    {
        return animator.GetCurrentFrame(layerIndex) == frame;
    }

    public static AnimationClip GetAnimationInfo(this Animator animator, int animationHash)
    {
        if (animator == null)
        {
            Debug.LogError("controller null");
            return null;
        }
        AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in animationClips)
        {
            int clipHash = Animator.StringToHash(clip.name);
            if (animationHash == clipHash) return clip;
        }
        Debug.LogError("controller null");
        return null;
    }

}
