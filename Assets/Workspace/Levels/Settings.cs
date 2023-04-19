using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/Create Settings")]
public class Settings : ScriptableObject
{
    [SerializeField]
    private bool _showHelper = true;
    [Space(20)]
    [SerializeField]
    private int _volumeLevel = 3;

    public bool ShowHelper { get => _showHelper; set => _showHelper = value; }

    public int VolumeLevel
    {
        get
        {
            return _volumeLevel;
        }

        set
        {
            if (_volumeLevel >= 0 || _volumeLevel <= 4)
            {
                _volumeLevel = value;
            }
        }
    }

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
}