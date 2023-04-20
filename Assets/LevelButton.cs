using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private TMP_Text _textfield;
    [SerializeField]
    private Image _image;

    private LevelsDataSet _activeDataSet;

    private int _id;

    public int Id { get => _id; set => _id = value; }
    public LevelsDataSet ActiveDataSet { set => _activeDataSet = value; }

    public void SetLevelIndex(int levelIndex)
    {
        _textfield.text = levelIndex.ToString();
    }

    public void SetClose()
    {
        _textfield.enabled = false;
        _image.enabled = true;
        _button.interactable = false;
    }

    public void SetOpen()
    {
        _textfield.enabled = true;
        _image.enabled = false;
        _button.interactable = true;
    }

    public void SetCurrentLevel()
    {
     //   _activeDataSet.CurrentLevelIndex = _id;
    }
}