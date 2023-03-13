using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterSetup : MonoListener
{
    [SerializeField]
    private TMP_Text _valueField;

    private LinearCounter _counter;
    private int _value = 0;


    private void Awake()
    {
        SetupCounter();
        SetupListeners();
    }

    private void SetupCounter()
    {
        _counter = new LinearCounter(_value);
        UpdateView();
    }

    public void UpdateView()
    {
        _valueField.text = _counter.Value.ToString();
    }

    protected override void SetupListeners()
    {
        base.SetupListeners();

        _listeners[0].AddAction(_counter.Increase);
        _listeners[1].AddAction(_counter.Reset);
        _listeners[0].AddAction(UpdateView);
        _listeners[1].AddAction(UpdateView);
    }
}