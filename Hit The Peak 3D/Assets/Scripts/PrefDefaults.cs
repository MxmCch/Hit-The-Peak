using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this in main menu to restart game difficulty
public class PrefDefaults : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        //dificulty 1easy 2medium 3hard 4global
        PlayerPrefs.SetInt("gameDifficulty", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
