using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _soundSource;
    [SerializeField]
    private Settings _settings;

    private EventListener _listnChangeLevel;

    readonly float[] _volumeLevels = new float[]
    {
        0f, 0.3f, 0.6f, 1f
    };

    private void Awake()
    {
        _listnChangeLevel = new EventListener(Events.ChangeSoundLevel);
        int volumeLevel = _settings.VolumeLevel;
        _soundSource.volume = _volumeLevels[volumeLevel];
    }

    public void ChangeVolume()
    {
        _soundSource.volume = _volumeLevels[_settings.VolumeLevel];
    }

    private void OnEnable()
    {
        _listnChangeLevel.Sub(ChangeVolume);
    }

    private void OnDisable()
    {
        _listnChangeLevel.UnSub(ChangeVolume);
    }
}
