using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField]
    Settings _settings;
    EventSender _sender;


    private CyclicCounter _counter;

    private void Awake()
    {
        _sender = new EventSender(Events.ChangeSoundLevel);
        int volumeLevel = _settings.VolumeLevel;
        _counter = new CyclicCounter(0, volumeLevel, 4);
    }

    public void ChangeVolume()
    {
        _counter.Increase();
        _settings.VolumeLevel = _counter.Value;
        _sender.SendEvent();
    }
}
