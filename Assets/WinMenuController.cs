using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuController : MonoListener
{
    private void Awake()
    {
        AddListener(Events.LevelEnd, Enable);
    }

    private void Enable()
    {
        List<Vector3> startPositions = new List<Vector3>(); 
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            startPositions.Add(transform.GetChild(i).position);
        }
        Disable();
    }

    private void Disable()
    {
        StartCoroutine(Delay(2.5f));
    }

    IEnumerator Delay(float sec)
    {
        yield return new WaitForSeconds(sec);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
