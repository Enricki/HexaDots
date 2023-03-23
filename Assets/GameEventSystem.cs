using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{



    private void Awake()
    {
        Events.Turn = ScriptableObject.CreateInstance<GameEvent>();
        Events.LevelEnd = ScriptableObject.CreateInstance<GameEvent>();
    }
}