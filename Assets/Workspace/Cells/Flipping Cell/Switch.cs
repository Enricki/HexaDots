using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch
{
    ICommand _onCommand;

    public Switch(ICommand onCommand)
    {
        _onCommand = onCommand;
    }

    public void MoveToNext()
    {
        _onCommand.Execute();
    }
}