using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCell : Cell
{
    private EventListener _listener;
    private EventSender _sender;



    private void Awake()
    {
        _listener = new EventListener(Events.Turn);
        _sender = new EventSender(Events.LevelEnd);
        transform.LeanScale(Vector2.zero, 1.2f).setEase(LeanTweenType.punch);
    }


    public void EndLevel()
    {
        if (HasUnit)
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
