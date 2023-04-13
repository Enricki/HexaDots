using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnim : MonoBehaviour
{
    [SerializeField]
    private Vector2 _startValue = Vector2.one;
    [SerializeField]
    private Vector2 _increasedValue = Vector2.one;
    [SerializeField]
    LeanTweenType animationType;
    [Space(20)]
    [SerializeField]
    Animations _appearanceAnimType;
    [SerializeField]
    Animations _idleAnimType;
    [SerializeField]
    Animations _exitAnimType;

    public Anima _currentAnim()
    {
        return animas[(int)_idleAnimType];
    }


    public delegate void Anima();
    public Anima _anima;

    List<Anima> animas = new List<Anima>();

    private void Start()
    {
        Bounce();
    }
    public void Punch()
    {
        transform.LeanScale(Vector2.zero, 1.2f).setEase(LeanTweenType.punch);
    }
    public Anima Bounce()
    {
        transform.localScale = _startValue;
        transform.LeanScale(_increasedValue, 0.8f).setLoopPingPong();
        return null;
    }

    public Anima Levitate()
    {
        _startValue = transform.localPosition;
        transform.LeanMoveLocalY(_increasedValue.y, 0.8f).setLoopPingPong();
        return null;
    }

    public Anima ScaleToZero()
    {
        transform.LeanScale(Vector2.zero, 0.25f);
        return null;
    }

    public Anima Shift(float x)
    {
        transform.LeanMoveLocalX(x, 0.5f).setEase(LeanTweenType.easeOutQuad);
        return null;
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0,0,-22));
        transform.LeanRotateZ(0f, 0.1f).setLoopCount(1);
     //   transform.localRotation = startRot;
    }

}

public enum Animations
{
    None = -1,
    Levitate,
    Bounce,
    ScaleToZero,
    Shift,
}