using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public Rigidbody bullet;
    public float bulletSpeed = 100.0f;

	void Update ()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Rigidbody thisBullet = Instantiate(bullet, transform.position, transform.rotation);
            thisBullet.velocity = thisBullet.transform.forward * bulletSpeed;
        }        	
	}
}
