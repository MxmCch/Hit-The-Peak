using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        other.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hit");
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
