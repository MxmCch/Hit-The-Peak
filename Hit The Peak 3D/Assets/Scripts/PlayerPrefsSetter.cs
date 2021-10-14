using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSetter : MonoBehaviour
{
    public int gameDif;

    void Start()
    {
        gameDif = PlayerPrefs.GetInt("gameDifficulty");
    }

    void Update()
    {
        
    }
}
