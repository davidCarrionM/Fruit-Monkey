using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranade : MonoBehaviour
{
    //Añadir headers
    public float throwForce = 500;
    public float throwUpwardForce = 100;
    public float ShotRate = 5f;
    private float shotRateTime = 0f;
    public Transform spawnGranade;
    public Transform cam;
    public GameObject granade;
    private float bombTime = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.time > shotRateTime)
            {
                GranadeThrow();
                shotRateTime = Time.time + ShotRate;
                bombTime = 0.0f;
            }
        }
            bombTime = shotRateTime - Time.time;
            GameManager.Instance.bomb = bombTime;
    }
    public void GranadeThrow()
    {
        GameObject newGranade = Instantiate(granade, spawnGranade.position, cam.rotation);
        Rigidbody granadeRb = newGranade.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        granadeRb.AddForce(forceToAdd, ForceMode.Impulse);
    }

}
