using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Text healthText;
    public int currentHealth;

    public Text ammoText;
    public int maxAmmo;
    public int currentAmmo;

    public Text scoreText;
    public int highScore;
    public int currentScore;

    [SerializeField]
    GameObject deathScreen;

    ChangeTarget changeTarget;
    
    public string currentWeapon;
    public int currentMap;

    private void Start() 
    {
        //load saved data
        changeTarget = this.GetComponent<ChangeTarget>();

    }
    
    void Update()
    {
        healthText.text = currentHealth.ToString();
        ammoText.text = currentAmmo.ToString();
        scoreText.text = currentScore.ToString();

        if (currentHealth <= 0)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        currentWeapon = changeTarget.playerWeapon;
        currentMap = SceneManager.GetActiveScene().buildIndex;
        
        currentHealth = 0;
        healthText.text = currentHealth.ToString();
        deathScreen.SetActive(true);
        StartCoroutine(CheckHighScore());

        yield return new WaitForEndOfFrame();

        deathScreen.transform.GetChild(2).GetComponent<Text>().text = currentScore.ToString();
        deathScreen.transform.GetChild(4).GetComponent<Text>().text = highScore.ToString();

        string mapName = "Map Name";
        if (currentMap == 1)
        {
            mapName = "Mirage";
        }
        else if (currentMap == 2)
        {
            mapName = "Inferno";
        }
        else if (currentMap == 3)
        {
            mapName = "Dust2";
        }
        else if (currentMap == 4)
        {
            mapName = "Cache";
        }

        deathScreen.transform.GetChild(5).GetComponent<Text>().text = currentWeapon + " - " + mapName;
        yield return new WaitForEndOfFrame();

        Time.timeScale = 0;
    }

    IEnumerator CheckHighScore()
    {

        highScore = PlayerPrefs.GetInt("highScore"+currentWeapon+currentMap, 0);
        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt("highScore"+currentWeapon+currentMap, currentScore);
        }

        yield return null;
    }
}
