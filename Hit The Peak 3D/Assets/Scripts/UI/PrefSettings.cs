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

    public Slider sfxImage;
    //public Slider musicImage; 
    
    private void Start() {
        SoundOption(sfxImage, "SFXVolume");
        //SoundOption(musicImage, "MusicVolume");
    }
    
    private void SoundOption(Slider text, string playerPrefName)
    {
        float lastSound = PlayerPrefs.GetFloat(playerPrefName);

        text.value = lastSound;

        masterMixer.SetFloat(playerPrefName, lastSound);
    }
}
