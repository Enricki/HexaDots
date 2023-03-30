using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterSetup : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _valueField;
    private LinearCounter _counter;
    private EventListener _turnListener;
    private EventListener _endOfLevel;
    private int _value = 0;

    private void Awake()
    {
        SetupCounter();
    }

    private void SetupCounter()
    {
        _counter = new LinearCounter(_value);
        _turnListener = new EventListener(Events.Turn);
        _endOfLevel = new EventListener(Events.LevelEnd);

        UpdateView();
    }

    public void UpdateView()
    {
        _valueField.text = _counter.Value.ToString();
    }

    private void OnEnable()
    {
        _turnListener.EventHook += _counter.Increase;
        _turnListener.EventHook += UpdateView;
        _turnListener.Subscribe();

        _endOfLevel.EventHook += _counter.Reset;
        _endOfLevel.EventHook += UpdateView;
        _endOfLevel.Subscribe();
    }

    private void OnDisable()
    {
        _turnListener.EventHook -= _counter.Increase;
        _turnListener.EventHook -= UpdateView;
        _turnListener.UnSubscribe();

        _endOfLevel.EventHook -= _counter.Reset;
        _endOfLevel.EventHook -= UpdateView;
        _endOfLevel.UnSubscribe();
    }
}