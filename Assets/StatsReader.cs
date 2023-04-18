using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsReader : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textField;
    [SerializeField]
    private LevelsDataSet _levelSet;

    private EventListener _listener;

    private void Awake()
    {
        _listener = new EventListener(Events.LevelEnd);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _textField.text = _levelSet.CurrentLevelIndex.ToString();
    }

    private void OnEnable()
    {
        _listener.EventHook += UpdateVisual;
        _listener.Subscribe();
    }

    private void OnDisable()
    {
        _listener.EventHook -= UpdateVisual;
        _listener.UnSubscribe();
    }
}
