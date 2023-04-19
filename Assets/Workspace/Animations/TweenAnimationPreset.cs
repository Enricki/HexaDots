using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TweenAnimationPreset : ScriptableObject
{
    [SerializeField]
    LeanTweenType _animationType = LeanTweenType.linear;
    [Space(5)]
    [SerializeField]
    private bool _usePinPongLoop = false;
    [Space(5)]
    [SerializeField]
    protected float _time = 1f;
    [SerializeField]
    private float _delay = 0;


    protected LTDescr _tween = null;

    public LTDescr Tween { get => _tween; }

    public virtual void PlayAnimation(Transform transform)
    {
        _tween.setEase(_animationType).setDelay(_delay);
        if (_usePinPongLoop)
        {
            _tween.setLoopPingPong();
        }
    }
}
