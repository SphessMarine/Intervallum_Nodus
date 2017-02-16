using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public Transform player;
    public float enemySpeed = 2.0f;


    void Update()
    {

        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        // GetComponent<Rigidbody>().AddForce(transform.forward * enemySpeed);
        transform.Translate(0.0f, 0.0f, enemySpeed * Time.deltaTime);
    }
}
