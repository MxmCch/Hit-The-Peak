using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField]
    PlayerStats playerStats;
    [SerializeField]
    ChangeTarget changeTarget;

    private void Awake() 
    {
        playerStats = playerStats.GetComponent<PlayerStats>();
        changeTarget = changeTarget.GetComponent<ChangeTarget>();
    }

    private void OnEnable()
    {
        DefaultStats(10);
    }

    public void DefaultStats(int ammoAmount)
    {
        playerStats.currentHealth = 100;
        playerStats.currentAmmo = ammoAmount;
        playerStats.currentScore = 0;
        changeTarget.canShoot = true;
        changeTarget.isReloading = false;
    }
}
