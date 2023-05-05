using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreVisual : MonoBehaviour, IView
{
    [SerializeField]
    LevelButton _levelButton;
    [SerializeField]
    private DataSetsKeeper _keeper;
    private List<Image> _images;

    private Color _default;
    private Color _achieved;


    private void Awake()
    {
        _images = new List<Image>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Image image = transform.GetChild(i).GetComponent<Image>();
            _images.Add(image);
        }
        UpdateView();
    }

    public void UpdateView()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        ColorUtility.TryParseHtmlString("#FFA320", out _achieved);
        ResetView();
        int levelID = _levelButton.Id;
        int achievedStars = dataSet.GetLevelDataByIndex(levelID).AchievedScore;
        for (int i = 0; i < achievedStars; i++)
        {
            Image image = _images[i];
            image.color = _achieved;
        }
    }




    private void ResetView()
    {
        ColorUtility.TryParseHtmlString("#C8C8C8", out _default);
        for (int i = 0; i < _images.Count; i++)
        {
            Image image = _images[i];
            image.color = _default;

        }
    }
}

//C8C8C8  FFA320
