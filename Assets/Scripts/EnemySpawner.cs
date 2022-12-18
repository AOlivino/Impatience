using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour { 
    [SerializeField]
    private GameObject slimespawner;
    [SerializeField]
    private GameObject wispspawner;
    
    float swarmerInterval = 30f;
    float wispswarmerInterval = 20f;

    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, slimespawner));
        StartCoroutine(spawnEnemy(wispswarmerInterval, wispspawner));
        }

private IEnumerator spawnEnemy(float interval, GameObject enemy)
        {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(15f, 50f), Random.Range(15f, 50f), 0), Quaternion.identity);
        //Quaternion.identity means no rotation, parameters are the enemy, the location (x, y, z), and rotation
        StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
