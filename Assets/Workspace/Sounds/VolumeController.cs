using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _soundSource;

    private CyclicCounter _counter;
    private float[] _volumeLevels = new float[]
    {
        0f, 0.3f, 0.6f, 1f
    };

    private void Start()
    {
        _counter = new CyclicCounter(0, 2, 4);
        _soundSource.volume = _volumeLevels[2];
    }

    public void ChangeVolume()
    {
        _counter.Increase();
        _soundSource.volume = _volumeLevels[_counter.Value];
    }
}
