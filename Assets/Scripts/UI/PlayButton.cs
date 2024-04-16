using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private float time = 1f;
    private bool started = false;
    public void LoadScene(string sceneName)
    {
        if (started)
        {
            return;
        }
        StartCoroutine(PlayRoutine(sceneName));
    }

    IEnumerator PlayRoutine(string sceneName)
    {
        started = true;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
}
