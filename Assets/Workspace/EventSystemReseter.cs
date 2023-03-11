using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemReseter : MonoEventSender
{
    public static GameEvent ResetAll;
    protected override void CheckForSend()
    {
        InitSender(ResetAll);
        _sender.SendEvent();
    }
}
