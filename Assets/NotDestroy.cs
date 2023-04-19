using UnityEngine;

public class NotDestroy : MonoBehaviour
{
    private string Id;

    private void Awake()
    {
        Id = gameObject.name;
    }

    private void Start()
    {
        for (int i = 0; i < FindObjectsOfType<NotDestroy>().Length; i++)
        {
            if (FindObjectsOfType<NotDestroy>()[i] != this)
            {
                if (FindObjectsOfType<NotDestroy>()[i].Id == Id)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}