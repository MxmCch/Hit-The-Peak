using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunClass : MonoBehaviour
{
    public int ammoAmount;
    public float damageAmount;
    public float reloadTime;
    public float fireRate;
    public bool isAutomatic;
    public float recoilRate;
    public AudioClip gunSound;

    public AudioClip AWP_shot;
    public AudioClip AK_shot;
    public AudioClip M4_shot;
    public AudioClip USP_shot;

    public void GetRandomGun()
    {
        int weaponID;
        
        List<string> gunNames = new List<string>();

        gunNames.Add("AWP");
        gunNames.Add("AK");
        gunNames.Add("M4");
        gunNames.Add("USP");
    
        weaponID = Random.Range(0,gunNames.Count-1);
        string gunName = gunNames[weaponID];

        if (gunName == "AWP")
        {
            ammoAmount = 10;
            damageAmount = 15;
            reloadTime = 3.7f;
            fireRate = 1.46f;
            isAutomatic = false;
            gunSound = AWP_shot;
        }
        else if (gunName == "AK")
        {
            ammoAmount = 30;
            damageAmount = 6;
            reloadTime = 5f;
            fireRate = 0.1f;
            isAutomatic = true;
            gunSound = AK_shot;
        }
        else if (gunName == "M4")
        {
            ammoAmount = 30;
            damageAmount = 4;
            reloadTime = 3.1f;
            fireRate = 0.06f;
            isAutomatic = true;
            gunSound = M4_shot;
        }
        else if (gunName == "USP")
        {
            ammoAmount = 12;
            damageAmount = 2;
            reloadTime = 2.7f;
            fireRate = 0.15f;
            isAutomatic = false;
            gunSound = USP_shot;
        }
    }
}
