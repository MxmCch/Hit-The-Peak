using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public float speed = 1;
    float step = 0;

    private void OnEnable() 
    {
        this.transform.position = startPoint.transform.position;
        step = 0;
    }

    private void Update() {
        if (this.transform.position == endPoint.transform.position)
        {
            this.transform.position = startPoint.transform.position;
        }
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, endPoint.transform.position, step);
    }
}
