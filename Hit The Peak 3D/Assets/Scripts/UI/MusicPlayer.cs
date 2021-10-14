using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] gameMusic;
    public int currentSong;
    private AudioSource _audioSource;

    int currentQue = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        currentQue++;
        currentSong = Random.Range(0,gameMusic.Length);
        _audioSource.PlayOneShot(gameMusic[currentSong]);
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
