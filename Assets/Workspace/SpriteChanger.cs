using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private Image _image;
    private CyclicCounter _cyclicCounter;

    private void Start()
    {
        _cyclicCounter = new CyclicCounter(0, 2, _sprites.Length);
        _image.sprite = _sprites[2];
    }

    public void ChangeSprite()
    {
        _cyclicCounter.Increase();
        _image.sprite = _sprites[_cyclicCounter.Value];
    }
}
