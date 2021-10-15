using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float spawnDelay = 4;
    float spawnDelayDelayer;

    int gameDifficulty;

    private void Awake() 
    {
        gameDifficulty = PlayerPrefs.GetInt("gameDifficulty");
        
        if (gameDifficulty == 1)
        {
            spawnDelayDelayer = 0;
        } 
        else if (gameDifficulty == 2)
        {
            spawnDelayDelayer = 0.2f;
        } 
        else if (gameDifficulty == 3)
        {
            spawnDelayDelayer = 0.8f;
        } 
        else if (gameDifficulty == 4)
        {
            spawnDelayDelayer = 1;
        }    
    }

    bool skipOne = false;
    private void OnEnable() {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        
        if (skipOne)
        {
            while(true)
            {
                this.transform.GetChild(Random.Range(0,this.transform.childCount)).gameObject.SetActive(true);
                if (1.5f < spawnDelay)
                {
                    spawnDelay -= 0.15f * spawnDelayDelayer;
                }
                yield return new WaitForSeconds(spawnDelay);
            }
        }
        else
        {
            skipOne = true;
        }
    }
}
