using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]
    Settings _settings;
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private Image _image;
    private CyclicCounter _cyclicCounter;

    private void Start()
    {
        int volumeLevel = _settings.VolumeLevel;
        _cyclicCounter = new CyclicCounter(0, volumeLevel, _sprites.Length);
        _image.sprite = _sprites[volumeLevel];
    }

    public void ChangeSprite()
    {

        _cyclicCounter.Increase();
        _image.sprite = _sprites[_cyclicCounter.Value];
    }
}
