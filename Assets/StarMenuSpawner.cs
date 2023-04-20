using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuSpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _stars;
    [SerializeField]
    private LevelsDataSet _dataSet;
    private CyclicCounter _counter;
    private EventListener _endLevel;
    private int _startOnValue;
    private void Awake()
    {
        _endLevel = new EventListener(Events.LevelEnd);
        _startOnValue = _dataSet.CurrentLevelIndex;
        _counter = new CyclicCounter(0, _startOnValue, _dataSet.LevelsCount);
    }

    public void Check()
    {
        LevelParametrs currentlevel = _dataSet.GetLevelParamByIndex(_startOnValue);

        for (int i = 0; i < currentlevel.StarLevelsCount; i++)
        {
            if (_dataSet.TurnsCount <= currentlevel.GetStarLevel(i))
            {
                _dataSet.SetAchievedStars(_startOnValue, i);
                Debug.Log(currentlevel.AchievedStars);
                break;
            }
        }
    }


    private void Appear()
    {
        _stars[0].SetActive(true);
        Check();
    }

    private void OnEnable()
    {
        _endLevel.Subscribe(Appear);
    }

    private void OnDisable()
    {
        _endLevel.UnSubscribe(Appear);
    }
}