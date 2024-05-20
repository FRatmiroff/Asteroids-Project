using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Spawner spawner;
    public GameObject spawnerObj;

    void Awake()
    {
        spawnerObj = GameObject.FindGameObjectWithTag("GameController");
        spawner = spawnerObj.GetComponent<Spawner>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag != "Asteroid")
        {
            spawner.resetAsteroidsShot();
        }
    }
}
