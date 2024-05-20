using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public Spawner spawner;
    public GameObject spawnerObj;
    public GameObject explosion;

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
        if(collision.gameObject.tag == "Asteroid")
        {
            explode();
        }
    }

    void explode()
    {
        GameObject explosion1 = Instantiate(explosion, this.transform.position, this.transform.rotation);
        Destroy(explosion1, 0.35f);
    }
}
