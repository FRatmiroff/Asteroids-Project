using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    Vector2 screenBounds;
    public GameObject bulletPrefab;
    public Transform asteroidTransform;
    public Transform playerTransform;
    public GameObject shipGO;
    public ShipController SC;
    int hitsTaken;
    public FlashEffectScript FES;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Awake()
    {
        hitsTaken = 0;
        shipGO = GameObject.FindGameObjectWithTag("Player");
        playerTransform = shipGO.GetComponent<Transform>();
        SC = shipGO.GetComponent<ShipController>();
    }
    void Update()
    {
        // if(asteroidTransform.position.y < -5.85f)
        // {
        //     asteroidTransform.position = new Vector2(asteroidTransform.position.x, 5.85f);
        // }
        // if(asteroidTransform.position.y > 5.85f)
        // {
        //     asteroidTransform.position = new Vector2(asteroidTransform.position.x, -5.85f);
        // }
        // if(asteroidTransform.position.x < -9.8f)
        // {
        //     asteroidTransform.position = new Vector2(9.8f, asteroidTransform.position.y);
        // }
        // if(asteroidTransform.position.x > 9.8f)
        // {
        //     asteroidTransform.position = new Vector2(-9.8f, asteroidTransform.position.y);
        // }
        if(!SC.death)
        {
            asteroidTransform.position = Vector2.MoveTowards(asteroidTransform.position, playerTransform.position, 1.5f * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bomb")
        {
            if(hitsTaken < 4)
            {
                hitsTaken++;
                FES.Flash();
            } else {
                Destroy(gameObject);
                ScoreManager.instance.UpdateScore(500);
                ScoreManager.instance.HighScoreUpdate();
                hitsTaken = 0;
            }
            Debug.Log(hitsTaken);
        }
        
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
            ScoreManager.instance.UpdateScore(500);
            ScoreManager.instance.HighScoreUpdate();
        }
    }
}
