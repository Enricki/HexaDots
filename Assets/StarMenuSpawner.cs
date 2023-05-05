using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMenuSpawner : MonoListener
{
    [SerializeField]
    private DataSetsKeeper _keeper;
    [SerializeField]
    private List<GameObject> _stars;


    private void OnEnable()
    {
        Appear();
    }


    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _stars[i].SetActive(false);
        }
    }

    private void Appear()
    {
        LevelData currentlevel = _keeper.CurrentSet.GetCurrentLevelData();
        for (int i = 0; i < currentlevel.AchievedScore; i++)
        {
            _stars[i].SetActive(true);
        }
    }
}