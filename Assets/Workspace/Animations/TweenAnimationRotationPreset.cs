using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rotate Animation", menuName = "Tween Animation/Create Rotate Animation Preset")]
public class TweenAnimationRotationPreset : TweenAnimationPreset
{
    [Space(10)]
    [SerializeField]
    private bool _useStartRotation = true;
    [SerializeField]
    private float _startRotationValue;
    [Space(10)]
    [SerializeField]
    private float _rotationValue;

    public override void PlayAnimation(Transform transform)
    {
        if (_useStartRotation)
        {
            transform.Rotate(new Vector3(0, 0, _startRotationValue));
        }

        _tween = transform.LeanRotateZ(_rotationValue, _time);
        base.PlayAnimation(transform);
    }
}
