using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels/Create Dataset")]
public class LevelsDataSet : ScriptableObject
{
    [SerializeField]
    private int _currentLevelIndex;
    [SerializeField]
    private int _turnsCount;
    [SerializeField]
    private int _starsAchieved;

    [SerializeField]
    private List<LevelData> _levels;

    public int LevelsCount { get => _levels.Count; }

    public int CurrentLevelIndex { get => _currentLevelIndex; }

    public int TurnsCount { get => _turnsCount; }

    public int StarsAchieved { get => _starsAchieved; }
    public void SetTurnsCount(LevelDataWriter writer)
    {
        _turnsCount = writer.TurnsCount;
    }

    public void SetCurrentLevelIndex(LevelDataWriter writer)
    {
        _currentLevelIndex = writer.CurrentLevelIndex;
    }

    public void SetAchievedStars(LevelDataWriter writer)
    {
        _starsAchieved = writer.StarsAchieved;
    }

    public LevelData GetCurrentLevelData()
    {
        return _levels[CurrentLevelIndex];
    }

    public LevelData GetLevelDataByIndex(int index)
    {
        return _levels[index];
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