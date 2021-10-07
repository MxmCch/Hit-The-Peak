using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    GameObject startPosition;
    [SerializeField]
    GameObject endPosition;
    [SerializeField]
    float movementSpeed = 5;

    Vector3 vectorMovement;
    bool isMoving = false;

    void OnEnable() 
    {
        this.transform.position = startPosition.transform.position;
        isMoving = true;
    }

    void Update() 
    {
        vectorMovement = (-this.transform.position + endPosition.transform.position)/5;
        this.transform.position += vectorMovement * Time.deltaTime * movementSpeed;     
    }
}
