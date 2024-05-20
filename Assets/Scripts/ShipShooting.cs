using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public ScoreManager scoreManager;
    public int ammo;
    public int bombAmmo;
    public PauseMenu pauseMenu;

    [SerializeField] float bulletForce;
    void Start()
    {
        bulletForce = 20f;
        ammo = 5;
        bombAmmo = 0;
        scoreManager.UpdateAmmo(ammo);
        scoreManager.UpdateBomb(bombAmmo);
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammo > 0 && !pauseMenu.gamePaused)
        {
            ShootBullet();
            ammo--;
            scoreManager.UpdateAmmo(ammo);
        }
        if(Input.GetButtonDown("Fire2") && bombAmmo > 0 && !pauseMenu.gamePaused)
        {
            ShootBomb();
            bombAmmo--;
            scoreManager.UpdateBomb(bombAmmo);
        }
    }

    void ShootBullet()
    {
        if(pauseMenu.gamePaused == false)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void ShootBomb()
    {
        if(pauseMenu.gamePaused == false)
        {
            GameObject bomb = Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bombrb = bomb.GetComponent<Rigidbody2D>();
            bombrb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ammo")
        {
            ammo += 5;
            scoreManager.UpdateAmmo(ammo);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "BombBox")
        {
            bombAmmo += 1;
            scoreManager.UpdateBomb(bombAmmo);
            Destroy(collision.gameObject);
        }
    }
}
