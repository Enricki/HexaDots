using UnityEngine.Events;

public class EventListener
{
    private GameEvent _gameEvent;
    private UnityEvent _unityEvent;

    public delegate void PublicEvent();

    public event PublicEvent EventHook;

    public EventListener(GameEvent gameEvent)
    {
        _gameEvent = gameEvent;
    }

    public void EventRaised()
    {
        EventHook?.Invoke();
    }

    public void Subscribe()
    {
        _gameEvent.AddListener(this);
    }

    public void UnSubscribe()
    {
        _gameEvent.RemoveListener(this);
    }
}