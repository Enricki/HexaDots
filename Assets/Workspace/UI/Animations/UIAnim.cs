using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnim : MonoBehaviour
{
    [SerializeField]
    private Vector2 _startValue = Vector2.one;
    [SerializeField]
    private Vector2 _increasedValue = Vector2.one;
    [Space(20)]
    [SerializeField]
    Animations _animation;

    private delegate void AnimationType();
    private event AnimationType _type;

    public void Levitate()
    {
        transform.localScale = _startValue;
        transform.LeanScale(_increasedValue, 0.8f).setLoopPingPong();
    }

    public void Bounce()
    {
        _startValue = transform.localPosition;
        transform.LeanMoveLocalY(_increasedValue.y, 0.8f).setLoopPingPong();
    }

    private void Start()
    {
        _type.Invoke();
    }

    private void OnEnable()
    {

        if (_animation == Animations.Levitate)
        {
            _type += Levitate;
        }
        else if (_animation == Animations.Bounce)
        {
            _type += Bounce;
        }
        Debug.Log(_animation);

    }

    private void OnDisable()
    {
        if (_animation == Animations.Levitate)
        {
            _type -= Levitate;
        }
        else if (_animation == Animations.Bounce)
        {
            _type -= Bounce;
        }
    }
}

public enum Animations
{
    Levitate,
    Bounce
}
