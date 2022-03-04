using System.Collections;
using UnityEngine;

public class ShootSounds : MonoBehaviour
{
    [SerializeField]
    PlayerStats playerStats;

    public AudioClip AWP_shot;
    public AudioClip AWP_reload;
    public AudioClip AWP_zoom;

    public AudioClip AK_shot;
    public AudioClip AK_reload;

    public AudioClip M4_shot;
    public AudioClip M4_reload;

    public AudioClip USP_shot;
    public AudioClip USP_reload;

    [SerializeField]
    public AudioSource audioSource;
    
    private void Awake() 
    {
        playerStats = playerStats.GetComponent<PlayerStats>();
    }
    
    public void PlayReload(string weaponName)
    {
        AudioClip reloadSound = USP_reload;
        
        if (weaponName == "AWP")
        {
            reloadSound = AWP_reload;
        } 
        else if (weaponName == "AK")
        {
            reloadSound = AK_reload;
        }
        else if (weaponName == "M4")
        {
            reloadSound = M4_reload;
        }
        else if (weaponName == "USP")
        {
            reloadSound = USP_reload;
        }
        audioSource.GetComponent<AudioSource>().PlayOneShot(reloadSound);
    }

    public void PlayShot(string weaponName)
    {
        AudioClip shotSound = USP_shot;
        if (weaponName == "AWP")
        {
            shotSound = AWP_shot;
        } 
        else if (weaponName == "AK")
        {
            shotSound = AK_shot;
        }
        else if (weaponName == "M4")
        {
            shotSound = M4_shot;
        }
        else if (weaponName == "USP")
        {
            shotSound = USP_shot;
        }
        audioSource.GetComponent<AudioSource>().PlayOneShot(shotSound);
    }

    public void PlayZoom()
    {
        audioSource.GetComponent<AudioSource>().PlayOneShot(AWP_zoom);
    }
}
