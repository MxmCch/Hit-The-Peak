using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    [SerializeField]
    PlayerStats playerStats;
    [SerializeField]
    ShootSounds shootSounds;
    [SerializeField]
    AudioSource audioSource;

    // 1-noscope, 2-1xscope, 3-2xscope
    public int defaultFOV = 3;
    Quaternion defaultCameraRotation;
    public GameObject enemyGroup;

    [SerializeField]
    GameObject scopeSprite; 
    int next = 0;
    int enemyAmount;

    [SerializeField]
    float turnSpeed = 10;

    [SerializeField]
    GameObject startTarget;
    GameObject currentTarget;

    public bool canShoot = true;
    public bool isReloading = false;

    Coroutine reloadingCoroutine;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

//1awp 2ak 3m4 4usp
    public string playerWeapon;

    public int ammoAmount;
    public float damageAmount;
    public float reloadTime;
    public float fireRate;
    public bool isAutomatic;
    public float recoilRate;
    public AudioClip gunSound;
    public int enemyHealth;
    
    public AudioClip AWP_shot;
    public AudioClip AK_shot;
    public AudioClip M4_shot;
    public AudioClip USP_shot;

    public void SelectWeapon(string selectedWeapon)
    {
        if (selectedWeapon == "AWP")
        {
            playerWeapon = "AWP";
            ammoAmount = 10;
            damageAmount = 115;
            reloadTime = 3.7f;
            fireRate = 0.7f;
            isAutomatic = false;
            gunSound = AWP_shot;
        }
        else if (selectedWeapon == "AK")
        {
            playerWeapon = "AK";
            ammoAmount = 30;
            damageAmount = 50;
            reloadTime = 3.1f;
            fireRate = 0.1f;
            isAutomatic = true;
            gunSound = AK_shot;
        }
        else if (selectedWeapon == "M4")
        {
            playerWeapon = "M4";
            ammoAmount = 30;
            damageAmount = 40;
            reloadTime = 3.1f;
            fireRate = 0.07f;
            isAutomatic = true;
            gunSound = M4_shot;
        }
        else if (selectedWeapon == "USP")
        {
            playerWeapon = "USP";
            ammoAmount = 12;
            damageAmount = 33;
            reloadTime = 2.7f;
            fireRate = 0.15f;
            isAutomatic = false;
            gunSound = USP_shot;
        }
    }
    float recoil = 1;
    void Start()
    {
        playerStats = playerStats.GetComponent<PlayerStats>();
        shootSounds = shootSounds.GetComponent<ShootSounds>();

        currentTarget = startTarget;
        enemyAmount = enemyGroup.transform.childCount;
        defaultCameraRotation = this.transform.rotation;
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }
 
    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            if (currentTarget.GetComponent<EnemyOrder>().swipeLeft)
                            {
                                currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeLeft;
                            }
                        }
                        else
                        {   //Left swipe
                            if (currentTarget.GetComponent<EnemyOrder>().swipeRight)
                            {
                                currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeRight;
                            }
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            if (currentTarget.GetComponent<EnemyOrder>().swipeDown)
                            {
                                currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeDown;
                            }
                        }
                        else
                        {   //Down swipe
                            if (currentTarget.GetComponent<EnemyOrder>().swipeUp)
                            {
                                currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeUp;
                            }
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                
                }
            }
        }
        recoil = Mathf.Lerp(recoil,1, Time.deltaTime);
        Quaternion wantedRotation = Quaternion.LookRotation(- transform.position + currentTarget.transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * turnSpeed);
    }

    public void LookLeft()
    {
        if (currentTarget.GetComponent<EnemyOrder>().swipeRight)
        {
            currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeRight;
        }
    }
    public void LookUp()
    {
        if (currentTarget.GetComponent<EnemyOrder>().swipeDown)
        {
            currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeDown;
        }
    }
    public void LookRight()
    {
        if (currentTarget.GetComponent<EnemyOrder>().swipeLeft)
        {
            currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeLeft;
        }
    }
    public void LookDown()
    {
        if (currentTarget.GetComponent<EnemyOrder>().swipeUp)
        {
            currentTarget = currentTarget.GetComponent<EnemyOrder>().swipeUp;
        }
    }

    public void ShootEnemy()
    {
        Vector3 randomSpray;
        if (defaultFOV == 1 && playerWeapon == "AWP")
        {
            randomSpray = new Vector3(Random.Range(-15,15),Random.Range(-15,15),0);
        }
        else
        {
            randomSpray = new Vector3(0,0,0);
        }

        //check if has ammo
        if (playerStats.currentAmmo <= 0 && !isReloading)
        {
            //shootSounds.NoAmmo();
            canShoot = false;
            StartReloadAmmo();
        }
        else
        {
            if (canShoot && !isReloading)
            {
                shootSounds.PlayShot(playerWeapon);

                playerStats.currentAmmo = playerStats.currentAmmo - 1;

                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward)+randomSpray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemyShooting>().enemyHealth = hit.transform.GetComponent<EnemyShooting>().enemyHealth - Mathf.RoundToInt(damageAmount);
                    }
                }
                Quaternion wantedRotation = Quaternion.LookRotation(- transform.position + currentTarget.transform.position + new Vector3(0,recoil,0));
                transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime*5);
                
                recoil++;
            }
        }
    }

    bool justShot = true;
    Coroutine Shooting;
    public void BeginShooting()
    {
        if (justShot)
        {
            justShot = false;
            Shooting = StartCoroutine(ShootPlayer());
            StartCoroutine(ShootCheck());
        }
    }
    IEnumerator ShootCheck()
    {
        yield return new WaitForSeconds(fireRate);
        justShot = true;
    }

    public void StopShooting()
    {
        StopCoroutine(Shooting);
    }

    IEnumerator ShootPlayer()
    {
        if (isAutomatic)
        {
            while (true)
            {
                ShootEnemy();
                yield return new WaitForSeconds(fireRate);
                justShot = true;
            } 
        }
        else
        {
            ShootEnemy();
            scopeSprite.SetActive(false);
            this.GetComponent<Camera>().fieldOfView = 55;
            defaultFOV = 1;
            yield return new WaitForSeconds(fireRate);
            justShot = true;
        }
    }
    
    public void StartReloadAmmo()
    {
        if (!isReloading)
        {
            reloadingCoroutine = StartCoroutine(ReloadAmmo());
        }
    }
    [SerializeField]
    GameObject reloadWheel;

    IEnumerator ReloadAmmo()
    {
        //StartCoroutine(ReloadVisual());
        shootSounds.PlayReload(playerWeapon);
        isReloading = true;
        canShoot = false;
        yield return new WaitForSeconds(reloadTime/2);
        playerStats.currentAmmo = playerStats.maxAmmo;
        canShoot = true;
        isReloading = false;
    }

    IEnumerator ReloadVisual()
    {   
        reloadWheel.SetActive(true);
        while (reloadWheel.GetComponent<Image>().fillAmount < 1)
        { 
            reloadWheel.GetComponent<Image>().fillAmount = Mathf.Lerp(0,1,Time.deltaTime/reloadTime); 
        }
        yield return null;
        reloadWheel.SetActive(false);
    }

    public void ScopeZoom()
    {
        if (playerWeapon == "AWP")
        {
            shootSounds.PlayZoom();
            if (defaultFOV == 1)
            {
                scopeSprite.SetActive(true);
                this.GetComponent<Camera>().fieldOfView = 19;
                defaultFOV = 2;
                StartCoroutine(ShakeCamera());
            }
            else if (defaultFOV == 2)
            {
                scopeSprite.SetActive(false);
                this.GetComponent<Camera>().fieldOfView = 55;
                defaultFOV = 1;
            }
        }
    }

    IEnumerator ShakeCamera()
    {
        this.transform.Rotate(0,0,0.2f,Space.Self);
        yield return new WaitForSeconds(0.03f);
        this.transform.Rotate(0,0,-0.8f,Space.Self);
        yield return new WaitForSeconds(0.03f);
        this.transform.Rotate(0,0,0.8f,Space.Self);
        yield return new WaitForSeconds(0.03f);
        this.transform.Rotate(0,0,-0.8f,Space.Self);
        yield return new WaitForSeconds(0.1f);
        this.transform.Rotate(0,0,0.2f,Space.Self);
    }
}
