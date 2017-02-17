using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    public Rigidbody eBullet;
    public float bulletSpeed = 100.0f;
    public bool canShoot = true;
    public float delay = 1.0f;

    void Update()
    {
        if (canShoot)
        {
            Rigidbody thisBullet = Instantiate(eBullet, transform.position, transform.rotation);
            thisBullet.velocity = thisBullet.transform.forward * bulletSpeed;
            canShoot = false;
            StartCoroutine("Shoot", delay);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
