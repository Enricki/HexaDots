using UnityEngine;

public class NotDestroy : MonoBehaviour
{
    private static NotDestroy _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}