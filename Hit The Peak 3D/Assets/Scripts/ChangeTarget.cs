using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    // 1-noscope, 2-1xscope, 3-2xscope
    public int defaultFOV = 1;
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









    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
 
    void Start()
    {
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
                    Debug.Log("Tap");
                }
            }
        }
        
        Quaternion wantedRotation = Quaternion.LookRotation(- transform.position + currentTarget.transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.deltaTime * turnSpeed);
    }

    public void ShootEnemy()
    {
        Vector3 randomSpray;
        if (defaultFOV == 1)
        {
            randomSpray = new Vector3(Random.Range(-15,15),Random.Range(-15,15),0);
        }
        else
        {
            randomSpray = new Vector3(0,0,0);
        }
Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward)*100+randomSpray,Color.cyan,5);
            
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward)+randomSpray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
    }

    public void ScopeZoom()
    {
        if (defaultFOV == 1)
        {
            scopeSprite.SetActive(true);
            this.GetComponent<Camera>().fieldOfView = 19;
            defaultFOV = 2;
            StartCoroutine(ShakeCamera());
        }
        else if (defaultFOV == 2)
        {
            scopeSprite.SetActive(true);
            this.GetComponent<Camera>().fieldOfView = 7;
            defaultFOV = 3;
            StartCoroutine(ShakeCamera());
        }
        else if (defaultFOV == 3)
        {
            scopeSprite.SetActive(false);
            this.GetComponent<Camera>().fieldOfView = 60;
            defaultFOV = 1;
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
