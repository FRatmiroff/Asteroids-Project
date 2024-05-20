using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float respawnTime = 5.0f;
    Vector2 screenBounds;
    public GameObject smallAsteroidPrefab;
    public GameObject mediumAsteroidPrefab;
    public GameObject bigAsteroidPrefab;
    public GameObject ammoBoxPrefab;
    public GameObject bombBoxPrefab;
    public GameObject Spaceship;
    public ScoreManager scoreManager;
    int asteroidsShot;


    void Start()
    {
        asteroidsShot = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    void Update()
    {
        if(scoreManager.getScore() >= 80000)
        {
            respawnTime = 3.0f;
        }
        if(scoreManager.getScore() >= 60000)
        {
            respawnTime = 3.5f;
        }
        if(scoreManager.getScore() >= 40000)
        {
            respawnTime = 4.0f;
        }
        else if(scoreManager.getScore() >= 20000)
        {
            respawnTime = 4.5f;
        }
        Debug.Log(respawnTime);
    }

    void spawnAsteroid()
    {
        int rand = (int)Random.Range(1, 4);
        GameObject asteroidPrefab = smallAsteroidPrefab;
        if(rand == 1)
        {
            asteroidPrefab = smallAsteroidPrefab;
        }
        else if(rand == 2)
        {
            asteroidPrefab = mediumAsteroidPrefab;
        }
        else if(rand == 3)
        {
            asteroidPrefab = bigAsteroidPrefab;
        }
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

        GameObject asteroid = Instantiate(asteroidPrefab);
        asteroid.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
        Rigidbody2D asteroidRB = asteroid.GetComponent<Rigidbody2D>();
        asteroidRB.AddForce(new Vector2(Random.Range(1f, 3f) * neg, Random.Range(1f, 3f) * neg), ForceMode2D.Impulse);
    }

    void spawnSpaceship()
    {
        int rand = Random.Range(1, 3);
        int val = 2;
        if(rand == 1)
        {
            val = -2;
        } else {
            val = 2;
        }
        GameObject spaceship = Instantiate(Spaceship);
        spaceship.transform.position = new Vector2(screenBounds.x * val, Random.Range(-screenBounds.y, screenBounds.y));
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

    void spawnBomb()
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
        GameObject bombBox = Instantiate(bombBoxPrefab);
        bombBox.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
        Rigidbody2D bombBoxRB = bombBox.GetComponent<Rigidbody2D>();
        bombBoxRB.AddForce(new Vector2(Random.Range(1f, 3f) * neg, Random.Range(1f, 3f) * neg), ForceMode2D.Impulse);
    }

    public void asteroidAmmoBonus()
    {
        asteroidsShot++;
        if(asteroidsShot >= 5)
        {
            spawnAmmo();
            asteroidsShot = 0;
            Debug.Log("Ammo");
        }
        Debug.Log(asteroidsShot);
    }

    public void resetAsteroidsShot()
    {
        asteroidsShot = 0;
    }

    IEnumerator AsteroidWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroid();
            if(scoreManager.getScore() >= 10000 && Random.Range(1, 4) == 1)
            {
                spawnSpaceship();
                Debug.Log("Spaceship Spawned");
            }
            if(Random.Range(1, 4) == 3)
            {
                spawnAmmo();
            }
            if(Random.Range(1, 4) == 3)
            {
                spawnBomb();
            }
        }
    }
}
