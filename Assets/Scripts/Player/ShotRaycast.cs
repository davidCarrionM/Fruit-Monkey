using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRaycast : MonoBehaviour
{
    public float range = 10f;
    public float bulletForce = 1500f;
    public GameObject effect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            {
                Debug.Log("Objeto colisionado: "+ hit.collider.name);
                //GameObject effectObject = Instantiate(effect, hit.point, Quaternion.identity);
                //Destroy(effectObject, 5);

                if (hit.collider.GetComponent<Rigidbody>() != null)
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(hit.normal * -bulletForce);
                }
            }


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range);
    }
}
