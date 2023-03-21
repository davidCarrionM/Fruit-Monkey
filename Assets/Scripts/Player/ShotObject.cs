using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform InitialPosition;
    public float BulletSpeed = 1500f;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temporalBullet;

            temporalBullet = Instantiate(Bullet, InitialPosition.position ,InitialPosition.rotation);

            temporalBullet.GetComponent<Rigidbody>().AddForce(InitialPosition.forward * BulletSpeed);

            Destroy(temporalBullet, 5f);
        }    
    }
}
