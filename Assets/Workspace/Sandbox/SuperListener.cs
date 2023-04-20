using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperListener : MonoListener
{
    private void Awake()
    {
        AddListener(Events.Turn, Play);
        AddListener(Events.ResetLevel, Cancel);
        AddListener(Events.DropU, Hook);
    }


    private void Play()
    {
        Debug.Log("Play");
    }

    private void Cancel()
    {
        Debug.Log("Cancel");
    }

    private void Hook()
    {
        Debug.Log("Hook");
    }
}
