using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuSpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _transforms;
    [SerializeField]
    private LevelsDataSet _dataSet;


    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (_dataSet.TurnsCount <= _dataSet.GetLevelParamByIndex(_dataSet.CurrentLevelIndex).T1 && _dataSet.TurnsCount >= _dataSet.GetLevelParamByIndex(_dataSet.CurrentLevelIndex).T2)
        {
            Debug.Log(1);
            if (_dataSet.TurnsCount <= _dataSet.GetLevelParamByIndex(_dataSet.CurrentLevelIndex).T2 && _dataSet.TurnsCount >= _dataSet.GetLevelParamByIndex(_dataSet.CurrentLevelIndex).T3)
            {
                Debug.Log(2);
                if (_dataSet.TurnsCount <= _dataSet.GetLevelParamByIndex(_dataSet.CurrentLevelIndex).T3)
                {
                    Debug.Log(3);
                }
            }
        }
    }
}
