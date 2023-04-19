using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T>: MonoBehaviour where T: MonoBehaviour
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                {
                    Debug.Log("None instance of " + typeof(T) + ", that needed");
                }
            }
            return Instance;
        }
    }
}
