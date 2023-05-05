using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHelper : MonoBehaviour
{
    [SerializeField]
    Settings _settings;

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

    private void Awake()
    {
        Show();
    }


    public void Show()
    {
        bool show = _settings.ShowHelper;
        if (!show)
        {
            gameObject.SetActive(false);
        }
        _settings.ShowHelper = false;
    }
}
