using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuSpawner : MonoListener
{
    [SerializeField]
    private List<GameObject> _stars;

    private void Awake()
    {

    }



    public void Check()
    {
        //LevelData currentlevel = _dataSet.GetLevelParamByIndex(_startOnValue);

        //for (int i = 0; i < currentlevel.StarLevelsCount; i++)
        //{
        //    if (_dataSet.TurnsCount <= currentlevel.GetStarLevel(i))
        //    {
        //        _dataSet.SetAchievedStars(_startOnValue, i);
        //        break;
        //    }
        //}
    }


    private void Appear()
    {
        _stars[0].SetActive(true);
        Check();
    }
}