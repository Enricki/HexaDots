using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _level;

    private void Awake()
    {
        Instantiate(_level, transform);
    }
}
