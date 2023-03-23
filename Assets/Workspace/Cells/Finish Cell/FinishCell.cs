using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCell : Cell
{
    private EventListener _listener;
    private EventSender _sender;
    [SerializeField]
    private Unit _unit;

    private void Awake()
    {
        _listener = new EventListener(Events.Turn);
        _sender = new EventSender(Events.LevelEnd);
    }


    public void EndLevel()
    {
        if (_unit.GetPosition() == transform.position)
            _sender.SendEvent();
    }

    private void OnEnable()
    {
        _listener.EventHook += EndLevel;
        _listener.Subscribe();
    }

    private void OnDisable()
    {
        _listener.EventHook -= EndLevel;
        _listener.UnSubscribe();
    }
}
