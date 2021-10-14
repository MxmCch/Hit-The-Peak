using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SwitchMainMenu : MonoBehaviour
{
    float wait_time = 8.4f;

    void Start()
    {
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(4);
    }
}
