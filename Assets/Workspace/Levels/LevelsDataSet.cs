using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels/Create Dataset")]
public class LevelsDataSet : ScriptableObject
{
    [SerializeField]
    private int _currentLevelIndex;

    [SerializeField]
    private List<LevelParametrs> _levels;

    [SerializeField]
    private int _turnsCount;

    public int LevelsCount { get => _levels.Count; }

    public int CurrentLevelIndex { get => _currentLevelIndex; set => _currentLevelIndex = value; }

    public int TurnsCount { get => _turnsCount; set => _turnsCount = value; }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

    public LevelParametrs GetLevelParamByIndex(int index)
    {
        return _levels[index];
    }

    public void UpdateLevelStat(int index, bool achieved, int achievedStars)
    {
        LevelParametrs parametr = _levels[index];
        parametr.Unlocked = achieved;
        parametr.AchievedStars = achievedStars;
        _levels[index] = parametr;
    }


}

[System.Serializable]
public struct LevelParametrs
{
    [SerializeField]
    private Level _levelPrefab;
    [SerializeField]
    private int _turnsTo3Stars;
    [SerializeField]
    private int _turnsTo2Stars;
    [SerializeField]
    private int _turnsTo1Star;
    [Space(20)]

    [SerializeField]
    private bool _unlocked;
    [SerializeField]
    private int _achievedStars;

    public Level LevelPrefab { get => _levelPrefab; }
    public bool Unlocked { get => _unlocked; set => _unlocked = value; }
    public int AchievedStars { get => _achievedStars; set => _achievedStars = value; }

    public int T3 { get => _turnsTo3Stars; }
    public int T2 { get => _turnsTo2Stars; }
    public int T1 { get => _turnsTo1Star; }

    public void SetStars(int three, int two, int one)
    {
        _turnsTo3Stars = three;
        _turnsTo2Stars = two;
        _turnsTo1Star = one;
    }
}