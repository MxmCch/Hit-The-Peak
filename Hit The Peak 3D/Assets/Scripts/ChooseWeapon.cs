using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    [SerializeField]
    ChangeTarget changeTarget;
    PlayerStats playerStats;

    private void Awake() {
        Time.timeScale = 0;
        playerStats = changeTarget.gameObject.GetComponent<PlayerStats>();
    }

    public void ChooseWeaponButton(string gunName)
    {
        if (gunName == "AWP")
        {
            changeTarget.SelectWeapon("AWP");
            playerStats.currentAmmo = changeTarget.ammoAmount;
            playerStats.maxAmmo = changeTarget.ammoAmount;
            Time.timeScale = 1;
        }
        else if (gunName == "AK")
        {
            changeTarget.SelectWeapon("AK");
            playerStats.currentAmmo = changeTarget.ammoAmount;
            playerStats.maxAmmo = changeTarget.ammoAmount;
            Time.timeScale = 1;
        }
        else if (gunName == "M4")
        {
            changeTarget.SelectWeapon("M4");
            playerStats.currentAmmo = changeTarget.ammoAmount;
            playerStats.maxAmmo = changeTarget.ammoAmount;
            Time.timeScale = 1;
        }
        StartCoroutine(FadeAway());
    }

    IEnumerator FadeAway()
    {
        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(false);
        }
        this.GetComponent<Image>().raycastTarget = false;
        
        float timer = 200;
        Color changeAlpha = this.GetComponent<Image>().color;
        while (timer > 0)
        {
            changeAlpha.a = Mathf.Lerp(changeAlpha.a, 0, Time.deltaTime*1.3f);
            this.GetComponent<Image>().color = changeAlpha;
            timer -= 1;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
