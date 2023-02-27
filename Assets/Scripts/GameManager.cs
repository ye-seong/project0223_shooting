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

<<<<<<< HEAD
    public static GameManager gameManager;

    public GameObject[] enemybullet;

    public float godtime = 3;
=======
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
>>>>>>> 27a6b118003cbf77996d83e9c599b89154cb8540

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

    private void Awake() //ΩÃ±€≈Ê ∆–≈œ
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
        enemybullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i = 0; i < enemybullet.Length; i++)
        {
            Destroy(enemybullet[i]);
        }

        player.SetActive(false);
        Time.timeScale = 0;


    }

    public void RespawnPlayer()
    {
<<<<<<< HEAD
        Invoke("AlivePlayer", 0.3f);

        player.GetComponent<PolygonCollider2D>().enabled = false;

        StartCoroutine(Flicker());

        Invoke("GodTime", 3.0f);
    }
        
    IEnumerator Flicker()
    {
        int count = 0;
        while (count < 3)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.4f);
            player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.4f);
            count++;
        }
    }

    void GodTime()
    {
        player.GetComponent<PolygonCollider2D>().enabled = true;
=======
        life.enabled = false;
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i =0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
>>>>>>> 27a6b118003cbf77996d83e9c599b89154cb8540
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
