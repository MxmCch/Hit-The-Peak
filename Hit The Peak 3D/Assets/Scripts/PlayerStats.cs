using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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

    private void Start() 
    {
        //load saved data

    }
    
    void Update()
    {
        healthText.text = currentHealth.ToString();
        ammoText.text = currentAmmo.ToString();
        scoreText.text = currentScore.ToString();
    }
}
