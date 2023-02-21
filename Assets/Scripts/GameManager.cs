using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float curEnemySpawnDelay;
    public float nextEnemySpawnDelay;

    public GameObject player;

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
        int ranType = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 7);
        GameObject goEnemy = Instantiate(enemyPrefabs[ranType], spawnPoints[ranPoint].position, Quaternion.identity);
        Enemy enemyLogic = goEnemy.GetComponent<Enemy>();
        enemyLogic.playerObject = player;
        enemyLogic.Move(ranPoint);
    }

    public void GameOver()
    {
        
    }

    public void RespawnPlayer()
    {
        Invoke("AlivePlayer", 1.0f);
    }

    void AlivePlayer()
    {
        player.transform.position = Vector3.down * 4.2f;
        player.SetActive(true);
        Player playrLogic = player.GetComponent<Player>();
        playrLogic.isHit = false;
    }
}
