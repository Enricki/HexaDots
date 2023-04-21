using UnityEngine;


[CreateAssetMenu(fileName = "Level", menuName = "Levels/Create LevelData")]
public class LevelData : ScriptableObject
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

    public Level LevelPrefab { get => _levelPrefab; }
    public bool Unlocked { get => _unlocked; set => _unlocked = value; }
    public int AchievedStars { get => _achievedStars; }
    public int StarLevelsCount { get => _starLevels.Length; }

    public void SetAchievedStars(LevelDataWriter writer)
    {
        _achievedStars = writer.AchiedLevelStars;
        _unlocked = true;
        Debug.Log(_achievedStars);
    }

    public int GetStarLevel(int index)
    {
        return _starLevels[index];
    }
}