using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int index)
    {
        StartCoroutine(Delay(0.5f, index));
    }

    IEnumerator Delay(float sec, int sceneIndex)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(sceneIndex);
    }
}
