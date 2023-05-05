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

    }

    private void OnEnable()
    {
        PlayAnim(_appearanceAnimation);
        if (_idleAnimation != null)
        {
            _appearanceAnimation.Tween.setOnComplete(PlayIdle);
        }
    }

    public void PlayAnim(TweenAnimationPreset preset)
    {
        if (preset != null)
        {
            LeanTween.cancel(gameObject);
            preset.PlayAnimation(transform);
        }
    }

    public void PlayIdle()
    {
        PlayAnim(_idleAnimation);
    }

    public void PlayExit()
    {
        PlayAnim(_exitAnimation);
    }
}