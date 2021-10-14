using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    public bool active = true;
    public GameObject[] slides;
    
    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void MirageMid()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeDifficulty(int difficultyInt)
    {
        PlayerPrefs.SetInt("gameDifficulty", difficultyInt);
    }

    public void InfernoCSspawn()
    {
        SceneManager.LoadScene(2);
    }

    public void FastMode()
    {
        SceneManager.LoadScene(3);
    }

    public void OpenLink(string URL)
    {
        Application.OpenURL(URL);
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ExitGame ()
    {
        Application.Quit(); 
    }
    
    public void SetMasterVolume (TextMeshProUGUI text)
    {
        string playerPrefName = "MasterVolume";
        SoundOption(text, playerPrefName);
    }

    public void SetSFXVolume (TextMeshProUGUI text)
    {
        string playerPrefName = "SFXVolume";
        SoundOption(text, playerPrefName);
    }

    public void SetMusicVolume (TextMeshProUGUI text)
    {
        string playerPrefName = "MusicVolume";
        SoundOption(text, playerPrefName);
    }
    
    private void SoundOption(TextMeshProUGUI text, string playerPrefName)
    {
        float lastSound = PlayerPrefs.GetFloat(playerPrefName);
        float setSound = 0;

        if (lastSound == 0)
        {
            text.text = "OFF";
            setSound = -80f;
            masterMixer.SetFloat(playerPrefName, setSound);
        }else if (lastSound == -80)
        {
            text.text = "ON";
            setSound = 0;
            masterMixer.SetFloat(playerPrefName, setSound);
        }
        PlayerPrefs.SetFloat(playerPrefName, setSound);
    }
}
