using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scale Animation", menuName = "Tween Animation/Create Scale Animation Preset")]
public class TweenAnimationScalePreset : TweenAnimationPreset
{
    [Space(10)]
    [SerializeField]
    private bool _useStartValue = true;
    [SerializeField]
    private Vector2 _startScale = Vector2.one;
    [Space(10)]
    [SerializeField]
    private Vector2 _targetScale = Vector2.one;

    public override void PlayAnimation(Transform transform)
    {
        if (_useStartValue)
        {
            transform.localScale = _startScale;
        }

        _tween = transform.LeanScale(_targetScale, _time);
        base.PlayAnimation(transform);
    }
}
