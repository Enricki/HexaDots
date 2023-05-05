using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoListener, IWriter<int>
{
    [SerializeField]
    private DataSetsKeeper _keeper;
    private Level _currentLevel;

    private CyclicCounter _counter;
    private int _currentLevelIndex;

    public int Value { get => _counter.Value; private set => _currentLevelIndex = value; }

    private void Awake()
    {
        _counter = new CyclicCounter(0, _keeper.CurrentSet.CurrentLevelIndex, _keeper.CurrentSet.LevelsCount);


        LoadCurrentLevel();


        AddListener(Events.LevelEnd, _counter.Increase);
        AddListener(Events.LevelEnd, WriteData);
        AddListener(Events.LevelEnd, LoadCurrentLevel);
        AddListener(Events.DropU, LoadCurrentLevel);
        AddListener(Events.ResetLevel, LoadCurrentLevel);
    }

    private void LoadCurrentLevel()
    {
        if (_currentLevel != null)
            Destroy(_currentLevel.gameObject);
        StartCoroutine(DelayedLevelLoad(2f));
    }

    IEnumerator DelayedLevelLoad(float sec)
    {
        yield return new WaitForSeconds(sec);
        LevelsDataSet current = _keeper.CurrentSet;
        Level instance = current.GetLevelDataByIndex(current.CurrentLevelIndex).LevelPrefab;
        _currentLevel = Instantiate(instance, transform);
    }

    public void WriteData()
    {
        _currentLevelIndex = _counter.Value;
        _keeper.CurrentSet.SetCurrentLevelIndex(this);
    }
}