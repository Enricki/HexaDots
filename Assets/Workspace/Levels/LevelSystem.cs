using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelSystem : MonoBehaviour
{
    private Level _currentLevel;
    [SerializeField]
    private List<Level> _levels;

    private CyclicCounter _counter;

    EventListener _listener;

    private void Awake()
    {
        _listener = new EventListener(Events.LevelEnd);
        _counter = new CyclicCounter(0, _levels.Count - 1, false);
        _currentLevel = Instantiate(_levels[0], transform);
    }

    private void ChangeLevel()
    {
        _counter.Increase();
        Debug.Log(_counter.Value);
        Destroy(_currentLevel.gameObject);
        _currentLevel = Instantiate(_levels.ElementAt(_counter.Value), transform);

    }

    private void OnEnable()
    {
        _listener.EventHook += ChangeLevel;
        _listener.Subscribe();
    }

    private void OnDisable()
    {
        _listener.EventHook -= ChangeLevel;
        _listener.UnSubscribe();
    }
}