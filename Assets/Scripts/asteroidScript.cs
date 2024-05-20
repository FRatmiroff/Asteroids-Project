using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    [SerializeField] int asteroid;
    Vector2 screenBounds;
    public GameObject smallAsteroidPrefab;
    public GameObject mediumAsteroidPrefab;
    public GameObject bigAsteroidPrefab;
    public Transform asteroidTransform;

    public GameObject ammoBoxPrefab;
    public Spawner spawner;
    public GameObject spawnerObj;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Awake()
    {
        spawnerObj = GameObject.FindGameObjectWithTag("GameController");
        spawner = spawnerObj.GetComponent<Spawner>();
    }
    void Update()
    {
        if(asteroidTransform.position.y < -5.85f)
        {
            asteroidTransform.position = new Vector2(asteroidTransform.position.x, 5.85f);
        }
        if(asteroidTransform.position.y > 5.85f)
        {
            asteroidTransform.position = new Vector2(asteroidTransform.position.x, -5.85f);
        }
        if(asteroidTransform.position.x < -9.8f)
        {
            asteroidTransform.position = new Vector2(9.8f, asteroidTransform.position.y);
        }
        if(asteroidTransform.position.x > 9.8f)
        {
            asteroidTransform.position = new Vector2(-9.8f, asteroidTransform.position.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
            spawner.asteroidAmmoBonus();
            if(asteroid == 1)
            {
                smallAsteroidShot();
            }
            else if(asteroid == 2)
            {
                mediumAsteroidShot();
            } 
            else if(asteroid == 3)
            {
                bigAsteroidShot();
            }
            ScoreManager.instance.HighScoreUpdate();
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

    void smallAsteroidShot()
    {
        ScoreManager.instance.UpdateScore(300);
    }

    void mediumAsteroidShot()
    {
        Vector2 trantemp = new Vector2(asteroidTransform.position.x, asteroidTransform.position.y);
        GameObject smallAsteroid1 = Instantiate(smallAsteroidPrefab, asteroidTransform.position, asteroidTransform.rotation);
        GameObject smallAsteroid2 = Instantiate(smallAsteroidPrefab, trantemp, asteroidTransform.rotation);

        Rigidbody2D smallAsteroid1RB = smallAsteroid1.GetComponent<Rigidbody2D>();
        Rigidbody2D smallAsteroid2RB = smallAsteroid2.GetComponent<Rigidbody2D>();
        float v1 = Random.Range(-3f, 3f);
        float v2 = Random.Range(-3f, 3f);
        smallAsteroid1RB.AddForce(new Vector2(v1, v2), ForceMode2D.Impulse);
        smallAsteroid2RB.AddForce(new Vector2(v1 * -1f, v2 * -1f), ForceMode2D.Impulse);
        ScoreManager.instance.UpdateScore(200);
    }
    //y: -5.85f, 5.85f
    //x: -9.8f, 9.8f
    void bigAsteroidShot()
    {
        GameObject mediumAsteroid1 = Instantiate(mediumAsteroidPrefab, asteroidTransform.position, asteroidTransform.rotation);
        GameObject mediumAsteroid2 = Instantiate(mediumAsteroidPrefab, asteroidTransform.position, asteroidTransform.rotation);

        Rigidbody2D mediumAsteroid1RB = mediumAsteroid1.GetComponent<Rigidbody2D>();
        Rigidbody2D mediumAsteroid2RB = mediumAsteroid2.GetComponent<Rigidbody2D>();
        float v1 = Random.Range(-3f, 3f);
        float v2 = Random.Range(-3f, 3f);
        mediumAsteroid1RB.AddForce(new Vector2(v1, v2), ForceMode2D.Impulse);
        mediumAsteroid2RB.AddForce(new Vector2(v1 * -1f, v2 * -1f), ForceMode2D.Impulse);
        ScoreManager.instance.UpdateScore(100);
    }

    void spawnAmmo()
    {
        int rand2 = Random.Range(1, 3);
        int neg = 1;
        if(rand2 == 1)
        {
            neg = 1;
        } 
        else if(rand2 == 2)
        {
            neg = -1;
        }
        GameObject ammoBox = Instantiate(ammoBoxPrefab);
        ammoBox.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
        Rigidbody2D ammoBoxRB = ammoBox.GetComponent<Rigidbody2D>();
        ammoBoxRB.AddForce(new Vector2(Random.Range(1f, 3f) * neg, Random.Range(1f, 3f) * neg), ForceMode2D.Impulse);
        
    }
}
