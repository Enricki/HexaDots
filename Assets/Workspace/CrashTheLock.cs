using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashTheLock : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TweenAnimationController _animationController;
    [SerializeField]
    private Button _button;
    [Space(20)]
    [SerializeField]
    private AudioClip _clip;
    [SerializeField]
    private Sprite _sprite;



    private LinearCounter _counter;
    private int _punchesToCrash;

    private void Awake()
    {
        _punchesToCrash = 50;
        _counter = new LinearCounter(0);
    }

    public void Crash()
    {
        _counter.Increase();
        if (_counter.Value >= _punchesToCrash)
        {
            _audioSource.clip = _clip;
            _audioSource.Play();
            _image.sprite = _sprite;
            _button.enabled = false;
            _animationController.PlayExit();
        }
    }
}
