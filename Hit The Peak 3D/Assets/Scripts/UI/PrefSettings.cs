using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PrefSettings : MonoBehaviour
{
    public AudioMixer masterMixer;

    public TextMeshProUGUI masterImage;
    public TextMeshProUGUI sfxImage;
    public TextMeshProUGUI musicImage; 
    
    private void Start() {
        SoundOption(masterImage.GetComponent<TextMeshProUGUI>(), "MasterVolume");
        SoundOption(sfxImage.GetComponent<TextMeshProUGUI>(), "SFXVolume");
        SoundOption(musicImage.GetComponent<TextMeshProUGUI>(), "MusicVolume");
    }
    
    private void SoundOption(TextMeshProUGUI text, string playerPrefName)
    {
        float lastSound = PlayerPrefs.GetFloat(playerPrefName);

        if (lastSound == 0)
        {
            text.text = "ON";
        }else if (lastSound == -80)
        {
            text.text = "OFF";
        }

        masterMixer.SetFloat(playerPrefName, lastSound);
    }
}
