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

    float minSpeed = 4f;
    float maxSpeed = 7f;
    float movementSpeed;

    Vector3 vectorMovement;
    public bool reachedDestination = false;

    void OnEnable() 
    {
        movementSpeed = Random.Range(minSpeed,maxSpeed);
        this.transform.position = startPosition.transform.position;
        reachedDestination = false;
    }

    void Update() 
    {
        this.transform.LookAt(playerStats.gameObject.transform);
        float distance = Vector3.Distance(transform.position,endPosition.transform.position);
        
        if (distance < 0.2f)
        {
            reachedDestination = true;
        }

        if (distance > 0.2f)
        {
            vectorMovement = (-this.transform.position + endPosition.transform.position)/5;
            this.transform.position += vectorMovement * Time.deltaTime * movementSpeed;  
        }
    }
}
