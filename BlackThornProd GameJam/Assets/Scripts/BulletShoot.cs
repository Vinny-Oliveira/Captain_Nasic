﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour {

    public float fltVerticalSpeed;
    //private bool blnShot;

    public GameManager gameMng;
    public GameObject player;
    public GameObject bullet;

    // Update is called once per frame
    void Update() {
        MoveBullet();
    }

    // Make the bullet move forward
    void MoveBullet() {
        transform.Translate(0,fltVerticalSpeed * Time.deltaTime, 0); // Move
        Destroy(gameObject, 2.5f); // Destroy the bullet after 10 s
    }

    // Make bullet collide with the enemy
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            // Kill the Enemy and destroy both Enemy and Bullet
            //collision.GetComponent<EnemyMove>().blnDead = true;
            collision.GetComponent<EnemyMove>().intHealth--;
            if(collision.GetComponent<EnemyMove>().intHealth == 0)
            {
                collision.GetComponent<EnemyMove>().blnKilled = true;

            }
            fltVerticalSpeed = 0;
            Destroy(collision.gameObject, gameMng.fltAnimaDestroyEnemy);
            Destroy(bullet, gameMng.fltAnimaDestroyBullet);

            // Increase score
        }
    }
}
