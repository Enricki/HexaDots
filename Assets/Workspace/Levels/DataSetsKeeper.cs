using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetsKeeper", menuName = "Levels/Create SetsKeeper")]
public class DataSetsKeeper : ScriptableObject
{
    [SerializeField]
    LevelsDataSet _currentSet;
    [SerializeField]
    List<LevelsDataSet> _dataSets;

    public LevelsDataSet CurrentSet { get => _currentSet; set => _currentSet = value; }
}
