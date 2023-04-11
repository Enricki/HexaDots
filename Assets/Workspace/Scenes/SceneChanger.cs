using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private float _delay = 0.5f;
    public void ChangeScene(int index)
    {
        StartCoroutine(Delay(_delay, index));
    }

    IEnumerator Delay(float sec, int sceneIndex)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(sceneIndex);
    }
}
