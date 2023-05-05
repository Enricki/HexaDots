using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels/Create Dataset")]
public class LevelsDataSet : ScriptableObject
{
    [SerializeField]
    private int _currentLevelIndex;
    [SerializeField]
    private int _turnsCount;
    [Space(20)]
    [SerializeField]
    private int _totalScoreAvaliable;
    [SerializeField]
    private int _currentScore;
    [SerializeField]
    private int _totalScoreAchieved;

    [SerializeField]
    private List<LevelData> _levels;

    public int LevelsCount { get => _levels.Count; }
    public int CurrentLevelIndex { get => _currentLevelIndex; }
    public int TurnsCount { get => _turnsCount; }
    public int TotalAvaliable { get => _totalScoreAvaliable; }
    public int TotalAchieved { get => _totalScoreAchieved; }

    public LevelData GetCurrentLevelData()
    {
        return _levels[CurrentLevelIndex];
    }

    public LevelData GetLevelDataByIndex(int index)
    {
        return _levels[index];
    }



    public void SetTurnsCount(IWriter<int> writer)
    {
        _turnsCount = writer.Value;
    }

    public void SetCurrentLevelIndex(IWriter<int> writer)
    {
        _currentLevelIndex = writer.Value;
    }


    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}

[Serializable]
public struct LevelDataView
{
    [SerializeField]
    private Level _levelPrefab;
    [Space(20)]
    [SerializeField]
    private int[] _starLevels;
    [SerializeField]
    private bool _unlocked;
    [SerializeField]
    private int _achievedStars;
}