using UnityEngine;
using System.Linq;
public sealed class LevelDataWriter : MonoListener
{
    [SerializeField]
    private DataSetsKeeper _keeper;
    private LinearCounter _turnsCounter;
    private CyclicCounter _levelsCounter;

    private int _achievedOnLevel;//

    public int TurnsCount { get => _turnsCounter.Value; }
    public int CurrentLevelIndex { get => _levelsCounter.Value; }
    public int AchiedLevelStars { get => _achievedOnLevel; }

    public int StarsAchieved { get => _achievedOnLevel; }

    private void Awake()
    {
        _turnsCounter = new LinearCounter(0);
        _levelsCounter = new CyclicCounter(0, _keeper.CurrentSet.CurrentLevelIndex, _keeper.CurrentSet.LevelsCount);

        AddListener(Events.Turn, _turnsCounter.Increase);
        AddListener(Events.Turn, WriteTurns);

        AddListener(Events.ResetLevel, _turnsCounter.Reset);
        AddListener(Events.ResetLevel, WriteTurns);

        AddListener(Events.LevelEnd, Check);//
        AddListener(Events.LevelEnd, WriteAchievedStars);//

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

    private void Check()
    {

        LevelsDataSet dataSet = _keeper.CurrentSet;
        int levelsCount = dataSet.GetCurrentLevelData().StarLevelsCount;
        int[] levels = new int[levelsCount];

        for (int i = 0; i < levelsCount; i++)
        {
            levels[i] = dataSet.GetCurrentLevelData().GetStarLevel(i);
        }

        _achievedOnLevel = CheckLevels(levels, dataSet.TurnsCount);
        Debug.Log(_achievedOnLevel);
    }

    private int CheckLevels(int[] levels, int checkValue) // Перенести в отдельный счетчик;
    {
        var sortedlevels = from i in levels
                           orderby i descending
                           select i;

        for (int i = sortedlevels.Count() - 1; i >= 0; i--)
        {
            if (checkValue <= sortedlevels.ElementAt(i))
            {
                return i + 1;
            }
        }
        return 0;
    }



    private void WriteAchievedStars()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        dataSet.GetCurrentLevelData().SetAchievedStars(this);
        dataSet.SetAchievedStars(this);
    }



    private void WriteCurrentLevelIndex()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        dataSet.SetCurrentLevelIndex(this);
    }

    private void WriteTurns()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        dataSet.SetTurnsCount(this);
    }
}