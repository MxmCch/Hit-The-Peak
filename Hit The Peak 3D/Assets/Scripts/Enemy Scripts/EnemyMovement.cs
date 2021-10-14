using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    GameObject startPosition;
    [SerializeField]
    GameObject endPosition;
    [SerializeField]
    PlayerStats playerStats;

    float minSpeed = 3.5f;
    float maxSpeed = 7;
    float movementSpeed;

    Vector3 vectorMovement;
    bool isMoving = false;
    public bool reachedDestination = false;

    int gameDifficulty;

    private void Awake() 
    {
        gameDifficulty = PlayerPrefs.GetInt("gameDifficulty");
    }

    void OnEnable() 
    {
        playerStats = playerStats.GetComponent<PlayerStats>();

        if (gameDifficulty == 1)
        {
            minSpeed = 2f;
            maxSpeed = 4f;
        } 
        else if (gameDifficulty == 2)
        {
            minSpeed = 3f;
            maxSpeed = 5f;
        } 
        else if (gameDifficulty == 3)
        {
            minSpeed = 4f;
            maxSpeed = 6f;
        } 
        else if (gameDifficulty == 4)
        {
            minSpeed = 4.5f;
            maxSpeed = 7.5f;
        }

        movementSpeed = Random.Range(minSpeed,maxSpeed);
        this.transform.position = startPosition.transform.position;
        isMoving = true;
    }

    void Update() 
    {
        float distance = Vector3.Distance(transform.position,endPosition.transform.position);
        
        if (distance < 0.2f)
        {
            reachedDestination = true;
        }
        
        vectorMovement = (-this.transform.position + endPosition.transform.position)/5;
        this.transform.position += vectorMovement * Time.deltaTime * movementSpeed;     
    }
}
