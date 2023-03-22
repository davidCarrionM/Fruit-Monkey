using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRaycast : MonoBehaviour
{
    public float Range = 10f;
    public float BulletForce = 1500f;
    public float ShotRate = 0.2f;
    private float shotRateTime = 0f;
    public GameObject EffectHit;
    public GameObject EffectShot;
    public Transform PositionShot;
    public GameObject Weapon;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shotRateTime)
            {

            RaycastHit hit;
            StartCoroutine(StartRecoil());
            if (Weapon.tag == "Gun")
            {
                GameObject shotEffect = Instantiate(EffectShot, PositionShot.position, PositionShot.rotation);
                Destroy(shotEffect, 1);
            }
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Range))
            {
                Debug.Log("Objeto colisionado: " + hit.collider.name);

                GameObject effectObject = Instantiate(EffectHit, hit.point, Quaternion.identity);
                Destroy(effectObject, 1);

                if (hit.collider.GetComponent<Rigidbody>() != null)
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(hit.normal * -BulletForce);
                }
            }
                shotRateTime = Time.time + ShotRate;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * Range);
    }

    IEnumerator StartRecoil()
    {
        if (Weapon.tag == "Gun")
        {
            Weapon.GetComponent<Animator>().Play("Recoil");
            yield return new WaitForSeconds(0.15f);
            Weapon.GetComponent<Animator>().Play("New State");
        }

        if (Weapon.tag == "Knife")
        {
            Weapon.GetComponent<Animator>().Play("KnifeAnimation");
            yield return new WaitForSeconds(0.3f);
            Weapon.GetComponent<Animator>().Play("New State");
        }
    }
}
