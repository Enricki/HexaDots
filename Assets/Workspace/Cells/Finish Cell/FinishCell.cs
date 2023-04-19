using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCell : Cell
{
    private EventListener _listener;
    protected EventSender _sender;

    private void Awake()
    {
        _listener = new EventListener(Events.Turn);
        _sender = new EventSender(Events.LevelEnd);
        transform.LeanScale(Vector2.zero, 1.2f).setEase(LeanTweenType.punch);
    }

    private void OnHasUnit()
    {
        if (HasUnit)
        {
            _sender.SendEvent();
        }
    }

    protected void OnEnable()
    {
        _listener.EventHook += OnHasUnit;
        _listener.Subscribe();
    }

    protected void OnDisable()
    {
        _listener.EventHook -= OnHasUnit;
        _listener.UnSubscribe();
    }
}