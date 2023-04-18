using UnityEngine;

public class CellTrigger : Cell
{
    private EventListener _listener;
    protected EventSender _sender;

    private void Awake()
    {
        _listener = new EventListener(Events.Turn);
        _sender = new EventSender(null);
        transform.LeanScale(Vector2.zero, 1.2f).setEase(LeanTweenType.punch);
    }
}