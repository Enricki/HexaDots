using System.Collections.Generic;
using UnityEngine;

public class MonoListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent[] _listeningEvents;
    protected List<EventListener> _listeners;

    private void Awake()
    {
        SetupListeners();
    }

    private void OnEnable()
    {
        foreach (var listener in _listeners)
        {
            listener.Subscribe();
        }
    }

    private void OnDisable()
    {
        foreach (var listener in _listeners)
        {
            listener.UnSubscribe();
        }
    }

    protected virtual void SetupListeners()
    {
        _listeners = new List<EventListener>();
        foreach (var gameEvent in _listeningEvents)
        {
            EventListener newListener = new EventListener(gameEvent);
            _listeners.Add(newListener);
        }
    }
}