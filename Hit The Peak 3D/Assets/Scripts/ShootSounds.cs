using System.Collections;
using UnityEngine;

public class ShootSounds : MonoBehaviour
{
    [SerializeField]
    AudioClip sniperShot;
    [SerializeField]
    AudioClip sniperZoom;
    [SerializeField]
    AudioSource audioSource;
    
    public void PlayShot()
    {
        //audioSource.GetComponent<AudioSource>().PlayOneShot(sniperShot);
    }
    public void PlayZoom()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(sniperZoom);
    }
}
