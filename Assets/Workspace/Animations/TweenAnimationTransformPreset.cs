using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Transform Animation", menuName = "Tween Animation/Create Transform Animation Preset")]
public class TweenAnimationTransformPreset : TweenAnimationPreset
{
    [Space(10)]
    [SerializeField]
    private bool _useStartPosition = true;
    [SerializeField]
    private Vector2 _startPosition;
    [Space(10)]
    [SerializeField]
    private Vector2 _targetPosition;

    public override void PlayAnimation(Transform transform)
    {
        if (_useStartPosition)
        {
            transform.localPosition = _startPosition;
        }

        _tween = transform.LeanMoveLocal(_targetPosition, _time);
        base.PlayAnimation(transform);
    }
}
