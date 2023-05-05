using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActions : MonoListener
{
    [SerializeField]
    AudioSource _audioSource;
    [SerializeField]
    ParticleSystem _particles;

    private void Awake()
    {
        AddListener(Events.LevelEnd, Action);
    }

    private void Action()
    {
        _audioSource.Play();
        _particles.Play();
    }
}
