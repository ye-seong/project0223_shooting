using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public float curEnemySpawnDelay;
    public float nextEnemySpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curEnemySpawnDelay += Time.deltaTime;
        if (curEnemySpawnDelay > nextEnemySpawnDelay)
        {
            SpawnEnemy();

            nextEnemySpawnDelay = Random.Range(0.5f, 3.0f);
            curEnemySpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);
        Instantiate(enemyPrefab, spawnPoints[ranPoint].position, Quaternion.identity);
    }
}
