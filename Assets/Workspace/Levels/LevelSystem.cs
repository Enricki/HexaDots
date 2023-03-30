using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    private List<LevelsDataSet> LevelSets;

    private LevelsDataSet _currentSet;
    private Level _currentLevel;


    private CyclicCounter _counter;

    EventListener _listener;

    EventListener _reset;

    private void Awake()
    {
        _listener = new EventListener(Events.LevelEnd);
        _reset = new EventListener(Events.DropU);
        _currentSet = LevelSets[0];
        _currentLevel = Instantiate(_currentSet.GetLevelByIndex(0), transform);

        _counter = new CyclicCounter(0, _currentSet.LevelsCount - 1, false);

    }

    private void ResetLevelOnDrop()
    {
        StartCoroutine(WaitForSeconds(0.3f));

    }

    private void ChangeLevel()
    {
        _counter.Increase();
        Destroy(_currentLevel.gameObject);
        _currentLevel = Instantiate(_currentSet.GetLevelByIndex(_counter.Value), transform);

    }

    private void OnEnable()
    {
        _listener.EventHook += ChangeLevel;
        _listener.Subscribe();

        _reset.EventHook += ResetLevelOnDrop;
        _reset.Subscribe();
    }

    private void OnDisable()
    {
        _listener.EventHook -= ChangeLevel;
        _listener.UnSubscribe();

        _reset.EventHook -= ResetLevelOnDrop;
        _reset.UnSubscribe();
    }

    IEnumerator WaitForSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(_currentLevel.gameObject);
        _currentLevel = Instantiate(_currentSet.GetLevelByIndex(_counter.Value), transform);
    }
}