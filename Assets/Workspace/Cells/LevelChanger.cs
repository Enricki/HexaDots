using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoListener
{
    private void ChangeLevel()
    {
        gameObject.SetActive(false);
    }

    protected override void SetupListeners()
    {
        base.SetupListeners();
        _listeners[0].AddAction(ChangeLevel);
    }
}