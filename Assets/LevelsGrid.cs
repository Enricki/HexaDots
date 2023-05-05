using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsGrid : MonoBehaviour
{
    [SerializeField]
    private LevelsDataSet _dataSet;
    [SerializeField]
    private List<LevelButton> _buttons;

    private string _butonName = "Button Level ";

    private void Awake()
    {
        UpdateGrid();
    }

    public void UpdateGrid()
    {
        _buttons.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            LevelButton button = transform.GetChild(i).GetComponent<LevelButton>();
            button.gameObject.name = _butonName + (i + 1);
            button.SetLevelIndex(i);
            button.Id = i;
            button.ActiveDataSet = _dataSet;
            button.SetOpen();
            if (_dataSet.GetLevelDataByIndex(i).Unlocked)
            {
                button.SetOpen();
            }
            else button.SetClose();

            _buttons.Add(button);
        }
    }
}
