using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private LevelsDataSet _levelSet;

    private int _id;

    public int ID { get => _id; }

    private void Start()
    {
        _id = _levelSet.CurrentLevelIndex;
    }

}