using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseChecker : MonoBehaviour
{
    public Canvas pausePanel;
    public bool pauseActive = false;

    private void Start() {
        Time.timeScale = 1;
        pauseActive = false;
    }

    void Update() {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
        pauseActive = true;
    }


    public void ResumeGame()
    {
        pauseActive = false;
    }
}
