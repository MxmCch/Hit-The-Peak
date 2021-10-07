using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float spawnDelay = 4;

    private void OnEnable() {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        while(true)
        {
            this.transform.GetChild(Random.Range(0,this.transform.childCount)).gameObject.SetActive(true);
            if (1.5f < spawnDelay)
            {
                spawnDelay -= 0.15f;
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
