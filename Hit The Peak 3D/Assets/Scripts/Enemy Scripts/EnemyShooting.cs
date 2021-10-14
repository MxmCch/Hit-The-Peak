using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    GunClass gunClass;
    [SerializeField]
    PlayerStats playerStats;
    
    EnemyMovement enemyMovement;

    public int ammoAmount;
    public float damageAmount;
    public float reloadTime;
    public float fireRate;
    public bool isAutomatic;
    public float recoilRate;
    public AudioClip gunSound;
    public int enemyHealth;
    
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    Text healthText;

    int usingWeapon;
    Coroutine shootCoroutine;
    bool nextShot = false;
    bool stopShooting = true;

    int gameDifficulty;
    // Start is called before the first frame update
    private void Awake() 
    {
        enemyMovement = this.GetComponent<EnemyMovement>();
        playerStats = playerStats.GetComponent<PlayerStats>();
        gameDifficulty = PlayerPrefs.GetInt("gameDifficulty");
    }

    private void Update() 
    {
        if (enemyHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnEnable() 
    {
        enemyHealth = 100;
        gunClass.GetComponent<GunClass>().GetRandomGun();
        
        if (gameDifficulty == 1)
        {
            ammoAmount = gunClass.ammoAmount;
            damageAmount = gunClass.damageAmount;
            reloadTime = gunClass.reloadTime;
            fireRate = gunClass.fireRate;
            isAutomatic = gunClass.isAutomatic;
            recoilRate = gunClass.recoilRate;
            gunSound = gunClass.gunSound;
        } 
        else if (gameDifficulty == 2)
        {
            ammoAmount = gunClass.ammoAmount;
            damageAmount = gunClass.damageAmount;
            reloadTime = gunClass.reloadTime;
            fireRate = gunClass.fireRate;
            isAutomatic = gunClass.isAutomatic;
            recoilRate = gunClass.recoilRate;
            gunSound = gunClass.gunSound;
        } 
        else if (gameDifficulty == 3)
        {
            ammoAmount = gunClass.ammoAmount;
            damageAmount = gunClass.damageAmount;
            reloadTime = gunClass.reloadTime;
            fireRate = gunClass.fireRate;
            isAutomatic = gunClass.isAutomatic;
            recoilRate = gunClass.recoilRate;
            gunSound = gunClass.gunSound;
        } 
        else if (gameDifficulty == 4)
        {
            ammoAmount = gunClass.ammoAmount;
            damageAmount = gunClass.damageAmount;
            reloadTime = gunClass.reloadTime;
            fireRate = gunClass.fireRate;
            isAutomatic = gunClass.isAutomatic;
            recoilRate = gunClass.recoilRate;
            gunSound = gunClass.gunSound;
        }
        Debug.Log(gunSound.name);
    }

    private void OnDisable() {
        playerStats.currentScore = playerStats.currentScore + 1; 
        StopCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        if (nextShot)
        {
            if (stopShooting)
            {
                stopShooting = false;
                float shootDelay = Random.Range(0.5f, 1.5f);
                //Random shoot sfx
                int randomShots = Random.Range(3,6);
                int damageDealt = Mathf.RoundToInt(damageAmount/randomShots);
                for (int i = 0; i < randomShots; i++)
                {
                    audioSource.PlayOneShot(gunSound);

                    StartCoroutine(DealDamage(damageDealt));
                    StartCoroutine(ShowDamage());

                    yield return new WaitForSeconds(fireRate);
                }

                yield return new WaitForSeconds(shootDelay);
                stopShooting = true;
            }
        }
    }

    IEnumerator DealDamage(int incrementedDamage)
    {
        yield return new WaitForSeconds(0.1f);
        playerStats.currentHealth = playerStats.currentHealth - incrementedDamage;
    }

    IEnumerator ShowDamage()
    {
        healthText.color = Color.red;
        yield return null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyMovement.reachedDestination)
        {
            nextShot = true;
            shootCoroutine = StartCoroutine(ShootPlayer());
        }
        else
        {
            if (shootCoroutine != null)
            {
                StopCoroutine(shootCoroutine);
                nextShot = false;
            }
        }
        Color lerpedColor = Color.Lerp(healthText.color, Color.white, Mathf.PingPong(Time.time, 0.3f));
        healthText.color = lerpedColor;
    }
}