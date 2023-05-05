using System;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Level", menuName = "Levels/Create LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private Level _levelPrefab;
    [SerializeField]
    private int[] _scoreLevels;
    [Space(20)]
    [SerializeField]
    private int _achievedScore;
    [SerializeField]
    private bool _unlocked;

    public Level LevelPrefab { get => _levelPrefab; }
    public bool Unlocked { get => _unlocked; set => _unlocked = value; }
    public int ScoreLevelsCount { get => _scoreLevels.Length; }
    public int AchievedScore { get => _achievedScore; }

   public void SetAchievedScore(IWriter<int> writer)
    {
        _achievedScore = writer.Value;
    }

    private int[] _sortedLevels
    {
        get
        {
            var sortedlevels = from i in _scoreLevels
                               orderby i descending
                               select i;
            return sortedlevels.ToArray();
        }
    }

    public int CheckCurrentLevel(int checkValue)
    {

        for (int i = _sortedLevels.Count() - 1; i >= 0; i--)
        {
            if (checkValue <= _sortedLevels.ElementAt(i))
            {
                return i + 1;
            }
        }
        return 0;
    }


    public int GetCurrentLevelValue(int checkValue)
    {
        int index = CheckCurrentLevel(checkValue) - 1;
        if (index >= 0)
        {
            return _sortedLevels[index];
        }
        else return _sortedLevels.First() + 1;
    }

    public int GetScoreLevelValue(int index)
    {
        return _scoreLevels[index];
    }
}