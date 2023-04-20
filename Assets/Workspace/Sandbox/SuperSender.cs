using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSender : MonoBehaviour
{
    private EventSender _turnSender;
    private EventSender _resetSender;
    private EventSender _dropUSender;

    private void Awake()
    {
        _turnSender = new EventSender(Events.Turn);
        _resetSender = new EventSender(Events.ResetLevel);
        _dropUSender = new EventSender(Events.DropU);
    }

    public void SendTurn()
    {
        _turnSender.SendEvent();
    }

    public void SendReset()
    {
        _resetSender.SendEvent();
    }

    public void SendDropU()
    {
        _dropUSender.SendEvent();
    }
}
