using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0f;

    public float power = 0f;

    public static float life = 3f;
    public bool isHit = false;

    public bool isTouchTop = false;
    public bool isTouchBottom = false;
    public bool isTouchRight = false;
    public bool isTouchLeft = false;

    Animator anim;

    public GameObject bulletPrefabA;
    public GameObject bulletPrefabB;

    public float curBulletDelay = 0f;
    public float maxBulletDelay = 1f;

    public int nScore;

    public static int CoinCount = 0;
    public static int BombCount = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        ReloadBullet();
    }

    private void FixedUpdate()
    {
        if (isHit)
        {
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return;
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        {
            h = 0;
        }
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        anim.SetInteger("Input", (int)h);
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (curBulletDelay < maxBulletDelay)
            return;

        Power();
        
        curBulletDelay = 0;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }

    void Power()
    {
        Bullet Bulletdamamge = bulletPrefabA.GetComponent<Bullet>();
        switch (power)
        {
            case 1:
                {                           
                    GameObject bullet = Instantiate(bulletPrefabA, transform.position, Quaternion.identity);
                    Rigidbody2D rd = bullet.GetComponent<Rigidbody2D>();
                    bulletPrefabA.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                    Bulletdamamge.power = 1;
                    rd.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                }
                break;
            case 2:
                {
                    GameObject bulletR = Instantiate(bulletPrefabA, transform.position, Quaternion.identity);
                    Rigidbody2D rdR = bulletR.GetComponent<Rigidbody2D>();
                    bulletPrefabA.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1f);
                    Bulletdamamge.power = 2;
                    rdR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                }
                break;
            case 3:
                {   
                    GameObject bulletC = Instantiate(bulletPrefabB, transform.position, Quaternion.identity);
                    Rigidbody2D rdC = bulletC.GetComponent<Rigidbody2D>();
                    rdC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                }
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBorder")
        {
            switch(collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (isHit)
                return;

            isHit = true;
            life--;

<<<<<<< HEAD
            GameManager gmLogic = gameMgrObj.GetComponent<GameManager>();

=======
>>>>>>> 27a6b118003cbf77996d83e9c599b89154cb8540
            if (life == 0)
            {
                GameManager.instance.GameOver();
            }
            else
            {
<<<<<<< HEAD
                gameObject.SetActive(false);
                gmLogic.RespawnPlayer();
            }
        }
        if (collision.gameObject.tag == "Poweritem")
        {
            power += 1;
            
            if (power > 3)
            {
                power = 3;
            }

            GameObject poweritem = GameObject.FindGameObjectWithTag("Poweritem");
            Destroy(poweritem);
        }
        if (collision.gameObject.tag == "Coinitem")
        {
            CoinCount += 1;

            GameObject coinitem = GameObject.FindGameObjectWithTag("Coinitem");
            Destroy(coinitem);
        } 
        if (collision.gameObject.tag == "Bombitem")
        {
            BombCount += 1;

            GameObject bombitem = GameObject.FindGameObjectWithTag("Bombitem");
            Destroy(bombitem);
=======
                GameManager.instance.RespawnPlayer();
                Invoke("Disappear", 1.0f); //=>코루틴으로 변경하면 변수를 넘길수 있어 더 편하게 시간관리를 쓸수 있다.
            }
>>>>>>> 27a6b118003cbf77996d83e9c599b89154cb8540
        }
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch(item.type)
            {
                case ItemType.Coin:
                    nScore += 100;
                    break;
                case ItemType.Power:
                    power++;
                    if (power >= 3)
                        power = 3;
                    break;
                case ItemType.Boom:
                    {
                        GameManager.instance.Boom();
                    }
                    break;
            }

            Destroy(collision.gameObject);
        }
    }

    void Disappear()
    {
        gameObject.SetActive(false);
        Invoke("Appear", 1f);
    }

    void Appear()
    {
        transform.position = Vector3.down * 4.2f;
        gameObject.SetActive(true);
        isHit = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBorder")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}
