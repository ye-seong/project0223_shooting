using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float curEnemySpawnDelay;
    public float nextEnemySpawnDelay;

    public Image life;

    public GameObject boomEffectObj;

    bool isShowEnemy = true;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curEnemySpawnDelay += Time.deltaTime;
        if (curEnemySpawnDelay > nextEnemySpawnDelay && isShowEnemy)
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
        enemyLogic.playerObject = GameObject.FindGameObjectWithTag("Player");
        enemyLogic.Move(ranPoint);
    }

    public void GameOver()
    {
        
    }

    public void RespawnPlayer()
    {
        life.enabled = false;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i =0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
    }

    public void Boom()
    {
        boomEffectObj.SetActive(true);
        Invoke("OffBoomEffect", 2.0f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemyLogic = enemies[i].GetComponent<Enemy>();
            enemyLogic.OnHit(1000);
            Destroy(enemies[i]);
        }
        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i = 0; i < enemyBullets.Length; i++)
        {
            Destroy(enemyBullets[i]);
        }

        isShowEnemy = false;

        Invoke("ShowEnemy", 3.0f);
    }

    void OffBoomEffect()
    {
        boomEffectObj.SetActive(false);
    }

    void ShowEnemy()
    {
        isShowEnemy = true;
        curEnemySpawnDelay = 0;
    }
    
}
