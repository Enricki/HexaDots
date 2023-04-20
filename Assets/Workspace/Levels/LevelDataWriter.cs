using UnityEngine;

public sealed class LevelDataWriter : MonoListener
{
    [SerializeField]
    private DataSetsKeeper _keeper;
    private LinearCounter _turnsCounter;
    private CyclicCounter _levelsCounter;
    private void Awake()
    {
        _turnsCounter = new LinearCounter(0);
        _levelsCounter = new CyclicCounter(0, _keeper.CurrentSet.CurrentLevelIndex, _keeper.CurrentSet.LevelsCount);

        AddListener(Events.Turn, _turnsCounter.Increase);
        AddListener(Events.Turn, WriteTurns);

        AddListener(Events.ResetLevel, _turnsCounter.Reset);
        AddListener(Events.ResetLevel, WriteTurns);

        AddListener(Events.LevelEnd, _turnsCounter.Reset);
        AddListener(Events.LevelEnd, WriteTurns);
        AddListener(Events.LevelEnd, _levelsCounter.Increase);
        AddListener(Events.LevelEnd, WriteCurrentLevelIndex);

    }
    private void OnDisable()
    {
        _turnsCounter.Reset();
        WriteTurns();
    }

    private void WriteCurrentLevelIndex()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        dataSet.CurrentLevelIndex = _levelsCounter.Value;
    }

    private void WriteTurns()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        dataSet.TurnsCount = _turnsCounter.Value;
    }
}