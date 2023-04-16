using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    //Añadir Headers
    public float delay = 3;
    float countdown;
    public float radius = 5;
    public float explosionForce = 70;
    bool exploded = false;
    public GameObject explosionEffect;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown<=0 && exploded == false)
        {
            Explote();
            exploded = true;
        }
    }

    private void Explote()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position,transform.rotation);
        Destroy(explosion,3);
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach (Collider item in colliders)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.AddExplosionForce(explosionForce*10, transform.position,radius);
            }
            if (item.gameObject.tag == "Body") {
                GameObject enemy = item.transform.root.gameObject;
                enemy.GetComponent<AI>().life -= 6;
                Debug.Log("Life: " + enemy.GetComponent<AI>().life);
            }

        }
        Destroy(gameObject);
    }
}
