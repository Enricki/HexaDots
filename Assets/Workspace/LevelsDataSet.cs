using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels/Create Dataset")]
public class LevelsDataSet : ScriptableObject
{
    [SerializeField]
    private List<Level> _levels;

    public int LevelsCount { get => _levels.Count; }

    public Level GetLevelByIndex(int index)
    {
        return _levels.ElementAt(index);
    }
}
