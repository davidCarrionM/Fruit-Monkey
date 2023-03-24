using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranade : MonoBehaviour
{

    public float throwForce = 500;
    public float throwUpwardForce = 100;
    public Transform spawnGranade;
    public Transform cam;
    public GameObject granade;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GranadeThrow();
        }    
    }
    public void GranadeThrow()
    {
        GameObject newGranade = Instantiate(granade, spawnGranade.position, cam.rotation);
        Rigidbody granadeRb = newGranade.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward* throwForce + transform.up * throwUpwardForce;

        granadeRb.AddForce(forceToAdd, ForceMode.Impulse);
    }

}
