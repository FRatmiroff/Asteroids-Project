using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private float moveHorizontal;
    private float moveVertical;
    public GameObject bulletPrefab;
    public Transform ship;
    public PauseMenu pauseMenu;
    public ScoreManager scoreManager;
    public bool death;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 1f;
        death = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if(pauseMenu.gamePaused == false)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = (Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal * speed, 0), ForceMode2D.Impulse);
        }
        if(moveVertical > 0.1f || moveVertical < 0.1f)
        {
            rb.AddForce(new Vector2(0, moveVertical * speed), ForceMode2D.Impulse);
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        pauseMenu.DeathScreen();
        scoreManager.Death();
        death = true;
        GameObject death1 = Instantiate(bulletPrefab, ship.position, ship.rotation);
        Rigidbody2D death1RB = death1.GetComponent<Rigidbody2D>();
        GameObject death2 = Instantiate(bulletPrefab, ship.position, ship.rotation);
        Rigidbody2D death2RB = death2.GetComponent<Rigidbody2D>();
        GameObject death3 = Instantiate(bulletPrefab, ship.position, ship.rotation);
        Rigidbody2D death3RB = death3.GetComponent<Rigidbody2D>();
        GameObject death4 = Instantiate(bulletPrefab, ship.position, ship.rotation);
        Rigidbody2D death4RB = death4.GetComponent<Rigidbody2D>();

        death1RB.AddForce(new Vector2(3f, 3f), ForceMode2D.Impulse);
        death2RB.AddForce(new Vector2(-3f, 3f), ForceMode2D.Impulse);
        death3RB.AddForce(new Vector2(3f, -3f), ForceMode2D.Impulse);
        death4RB.AddForce(new Vector2(-3f, -3f), ForceMode2D.Impulse);
    }
}
