using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    [SerializeField]
    ChangeTarget changeTarget;

    private void Awake() {
        Time.timeScale = 0;
    }

    public void ChooseWeaponButton(string gunName)
    {
        if (gunName == "AWP")
        {
            changeTarget.playerWeapon = "AWP";
            Time.timeScale = 1;
        }
        else if (gunName == "AK")
        {
            changeTarget.playerWeapon = "AWP";
            Time.timeScale = 1;
        }
        else if (gunName == "M4")
        {
            changeTarget.playerWeapon = "AWP";
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
        
        float timer = 150;
        float smoother = 0.1f;
        Color changeAlpha = this.GetComponent<Image>().color;
        while (timer > 0)
        {
            changeAlpha.a = Mathf.Lerp(changeAlpha.a, 0, Time.deltaTime*smoother);
            Debug.Log(changeAlpha.a);
            this.GetComponent<Image>().color = changeAlpha;
            timer -= 1;
            if (smoother != 1)
            {
                smoother += 0.02f;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
