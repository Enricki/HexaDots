using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    private List<LevelsDataSet> LevelSets;
    [SerializeField]
    private CounterSetup _turnCounter;


    private LevelsDataSet _currentSet;
    private Level _currentLevel;


    private CyclicCounter _counter;
    private EventSender _sendReset;

    private EventListener _listener;
    private EventListener _reset;
    private EventListener _dropU;

    private List<EventListener> _listeners;

    int _startOnValue;

    private void Awake()
    {
        _sendReset = new EventSender(Events.ResetLevel);

        _listeners = new List<EventListener>();
        _listeners.Add(new EventListener(Events.LevelEnd));


        _listener = new EventListener(Events.LevelEnd);
        _reset = new EventListener(Events.ResetLevel);
        _dropU = new EventListener(Events.DropU);

        _currentSet = LevelSets[0]; // ..........................................
        _startOnValue = _currentSet.CurrentLevelIndex;
        Level instance = _currentSet.GetLevelParamByIndex(_startOnValue).LevelPrefab;

        _currentLevel = Instantiate(instance, transform);

        _counter = new CyclicCounter(0, _startOnValue, _currentSet.LevelsCount);
    }

    public void SendResetLevel()
    {
        _sendReset.SendEvent();
    }

    private void ResetLevelOnDrop()
    {
        StartCoroutine(WaitForSeconds(0.3f));
    }

    private void ChangeLevel()
    {
    //    Destroy(_currentLevel.gameObject);

        _counter.Increase();
        int nextIndex = _counter.Value;

    //    _currentSet.CurrentLevelIndex = nextIndex;
     //   _currentSet.UpdateLevelStat(_counter.Value, true);

        //Level instance = _currentSet.GetLevelParamByIndex(_counter.Value).LevelPrefab;
        //_currentLevel = Instantiate(instance, transform);
    }

    private void OnEnable()
    {
        _listener.Subscribe(ChangeLevel);
        _reset.Subscribe(ResetLevelOnDrop);
        _dropU.Subscribe(ResetLevelOnDrop);
    }

    private void OnDisable()
    {
        _listener.UnSubscribe(ChangeLevel);
        _reset.UnSubscribe(ResetLevelOnDrop);
        _dropU.UnSubscribe(ResetLevelOnDrop);
    }

    IEnumerator WaitForSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(_currentLevel.gameObject);
        Level instance = _currentSet.GetLevelParamByIndex(_counter.Value).LevelPrefab;
        _currentLevel = Instantiate(instance, transform);
    }
}