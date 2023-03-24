using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{

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

        Instantiate(explosionEffect,transform.position,transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach (Collider item in colliders)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb!=null)
            {
                rb.AddExplosionForce(explosionForce*10, transform.position,radius);
            }
        }
        Destroy(gameObject);
    }
}
