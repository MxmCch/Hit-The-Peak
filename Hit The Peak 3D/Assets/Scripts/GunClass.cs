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

    int gameDifficulty;

    private void Awake() {
        gameDifficulty = PlayerPrefs.GetInt("gameDifficulty");
    }

    public void GetRandomGun()
    {
        int weaponID;

        //change string gunNames according to game difficutly /done

        gameDifficulty = PlayerPrefs.GetInt("gameDifficulty");
        
        List<string> gunNames = new List<string>();
        float dmgNerfer = 2f;
        float fireRateNerfer = 2f;

        if (gameDifficulty == 1)
        {
            gunNames.Add("AK");
            gunNames.Add("M4");
            gunNames.Add("USP");
            dmgNerfer = 3f;
            fireRateNerfer = 1.5f;
        } 
        else if (gameDifficulty == 2)
        {
            gunNames.Add("AK");
            gunNames.Add("M4");
            gunNames.Add("USP");
            dmgNerfer = 2f;
            fireRateNerfer = 1.3f;
        } 
        else if (gameDifficulty == 3)
        {
            gunNames.Add("AWP");
            gunNames.Add("AK");
            gunNames.Add("M4");
            dmgNerfer = 1.4f;
            fireRateNerfer = 1.1f;
        } 
        else if (gameDifficulty == 4)
        {
            gunNames.Add("AWP");
            gunNames.Add("AK");
            gunNames.Add("M4");
            dmgNerfer = 1f;
            fireRateNerfer = 1f;
        }

        Debug.Log(gunNames.Count);
        weaponID = Random.Range(0,gunNames.Count-1);
        string gunName = gunNames[weaponID];
        Debug.Log(gunName);
        if (gunName == "AWP")
        {
            ammoAmount = 10;
            damageAmount = 115 / dmgNerfer;
            reloadTime = 3.7f;
            fireRate = 1.46f * fireRateNerfer;
            isAutomatic = false;
            gunSound = AWP_shot;
        }
        else if (gunName == "AK")
        {
            ammoAmount = 30;
            damageAmount = 35/dmgNerfer;
            reloadTime = 2.4f;
            fireRate = 0.1f * fireRateNerfer;
            isAutomatic = true;
            gunSound = AK_shot;
        }
        else if (gunName == "M4")
        {
            ammoAmount = 30;
            damageAmount = 33/dmgNerfer;
            reloadTime = 3.1f;
            fireRate = 0.09f * fireRateNerfer;
            isAutomatic = true;
            gunSound = M4_shot;
        }
        else if (gunName == "USP")
        {
            ammoAmount = 12;
            damageAmount = 33/dmgNerfer;
            reloadTime = 2.7f;
            fireRate = 0.15f * fireRateNerfer;
            isAutomatic = false;
            gunSound = USP_shot;
        }
    }
}
