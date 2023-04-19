using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CounterSetup : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _valueField;
    [SerializeField]
    private int _value = 0;
    [Space(20)]
    [SerializeField]
    private UnityEvent _actionOnTurn;
    [SerializeField]
    private UnityEvent _actionOnEnd;

    private LinearCounter _counter;
    private EventListener _turnListener;
    private EventListener _endOfLevel;
    private EventListener _restartLevel;

    [SerializeField]
    private LevelsDataSet _set;

    public int Value { get => _value;}

    private void Awake()
    {
        SetupCounter();
    }

    private void SetupCounter()
    {
        _counter = new LinearCounter(_value);
        _turnListener = new EventListener(Events.Turn);
        _endOfLevel = new EventListener(Events.LevelEnd);
        _restartLevel = new EventListener(Events.ResetLevel);

        UpdateView();
    }

    public void UpdateView()
    {
        _valueField.text = _counter.Value.ToString();
    }

    private void OnEnable()
    {
        _turnListener.EventHook += _actionOnTurn.Invoke;
        _turnListener.Subscribe();

        _endOfLevel.EventHook += _actionOnEnd.Invoke;
        _endOfLevel.Subscribe();

        _restartLevel.EventHook += ResetCounter;
        _restartLevel.Subscribe();
    }

    private void OnDisable()
    {
        _turnListener.EventHook -= _actionOnTurn.Invoke;
        _turnListener.UnSubscribe();

        _endOfLevel.EventHook -= _actionOnEnd.Invoke;
        _endOfLevel.UnSubscribe();

        _restartLevel.EventHook -= ResetCounter;
        _restartLevel.UnSubscribe();
    }

    public void ResetCounter()
    {
        _set.TurnsCount = _counter.Value;
        _counter.Reset();
        UpdateView();
    }

    public void Increase()
    {
        _counter.Increase();
        UpdateView();
    }
}