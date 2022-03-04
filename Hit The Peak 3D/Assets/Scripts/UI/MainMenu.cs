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

    public Slider SFX_slider;
    public Slider Music_slider;

    [SerializeField]
    GameObject[] playerNames;
    
    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void MirageMid()
    {
        SceneManager.LoadScene(1);
    }

    public void InfernoCSspawn()
    {
        SceneManager.LoadScene(2);
    }

    public void Dust2Mode()
    {
        SceneManager.LoadScene(3);
    }

    public void CacheMode()
    {
        SceneManager.LoadScene(4);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    
    public void SetVolume ()
    {
        SoundOption(SFX_slider, Music_slider);
    }

    public void AWPList()
    {
        string[] nameList = {
            "simple - 100",
            "zywoo - 90",
            "device - 80",
            "kennyS - 70",
            "Jame - 60",
            "cadiaN - 50",
            "falleN - 40",
            "JW - 30",
            "mantuu - 20",
            "degster - 10"
        };
        int i = 0;
        foreach (GameObject item in playerNames)
        {
            item.GetComponent<Text>().text = nameList[i];
            i++;
        }
    }

    public void ARList()
    {
        string[] nameList = {
            "NiKo - 250",
            "b1T - 200",
            "eletronic - 175",
            "ropz - 150",
            "Twistzz - 125",
            "mir - 100",
            "ax1le - 80",
            "EliGE - 60",
            "hunter - 40",
            "hobbit - 20"
        };
        
        int i = 0;
        foreach (GameObject item in playerNames)
        {
            item.GetComponent<Text>().text = nameList[i];
            i++;
        }
    }
    
    private void SoundOption(Slider SFXslider, Slider MusicSlider)
    {
        float SFXSetSound = SFXslider.value;
        //float MusicSetSound = MusicSlider.value;

        masterMixer.SetFloat("SFXVolume", SFXSetSound);
        //masterMixer.SetFloat("MusicVolume", MusicSetSound);

        PlayerPrefs.SetFloat("SFXVolume", SFXSetSound);
        //PlayerPrefs.SetFloat("MusicVolume", MusicSetSound);
    }
}
