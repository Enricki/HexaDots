using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenAnimationController : MonoBehaviour
{
    [SerializeField]
    TweenAnimationPreset _appearanceAnimation;
    [SerializeField]
    TweenAnimationPreset _idleAnimation;
    [SerializeField]
    TweenAnimationPreset _exitAnimation;

    private void Awake()
    {
        PlayAnim(_appearanceAnimation);
    }

    public void PlayAnim(TweenAnimationPreset preset)
    {
        if (preset != null)
        {
            LeanTween.cancel(gameObject);
            preset.PlayAnimation(transform);
        }
    }
}