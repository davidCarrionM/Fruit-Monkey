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
    public GameObject bloodEfect;
    public Animator Animator;
    public Camera cam;
    public Camera camWeapon;
    public CamaraMovement camaraMovement;
    private bool aim = false;
    
    void Update()
    {
        if (Weapon.tag == "Gun")
        {
            if (Input.GetMouseButtonDown(1))
            {
                aim = true;
                Weapon.GetComponent<Animator>().Play("Aim");
                cam.GetComponent<Animator>().Play("CamaraFov");
                cam.fieldOfView = 30f;
                camWeapon.fieldOfView = 40f;
                camaraMovement.Sensibility = camaraMovement.Sensibility / 1.5f;
                Range = Range * 1.3f;
            }
            if (Input.GetMouseButtonUp(1))
            {
                aim = false;
                cam.fieldOfView = 80f;
                Weapon.GetComponent<Animator>().Play("AimBack");
                cam.GetComponent<Animator>().Play("CamaraFovBack");
                camWeapon.fieldOfView = 60f;
                camaraMovement.Sensibility = camaraMovement.Sensibility * 1.5f;
                Range = Range / 1.3f;
            }
        }
        if (Input.GetMouseButtonDown(0))
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
                    if (hit.collider.GetComponent<Rigidbody>() != null)
                    {
                        Debug.Log("Objeto colisionado: " + hit.collider.name + " tag: " + hit.collider.tag);
                        if (hit.collider.tag == "Head" || hit.collider.tag == "Body" || hit.collider.tag == "Extremities")
                        {
                            GameObject bloodObject = Instantiate(bloodEfect, hit.point, Quaternion.identity);
                            Destroy(bloodObject, 1);
                            if (Weapon.tag == "Knife")
                            {
                                GameObject enemy = hit.collider.transform.root.gameObject;
                                enemy.GetComponent<AI>().life -= 10;
                            }
                        }
                        else
                        {
                            GameObject effectObject = Instantiate(EffectHit, hit.point, Quaternion.identity);
                            Destroy(effectObject, 1);
                        }
                        if (hit.collider.tag == "Head") {
                            GameObject enemy = hit.collider.transform.root.gameObject;
                            enemy.GetComponent<AI>().life -= 6;
                            Debug.Log("Life: " + enemy.GetComponent<AI>().life);
                        }
                        if (hit.collider.tag == "Body")
                        {
                            GameObject enemy = hit.collider.transform.root.gameObject;
                            enemy.GetComponent<AI>().life -= 2;
                            Debug.Log("Life: " + enemy.GetComponent<AI>().life);
                         
                        }
                        if (hit.collider.tag == "Extremities")
                        {
                            GameObject enemy = hit.collider.transform.root.gameObject;
                            enemy.GetComponent<AI>().life -= 1;
                            Debug.Log("Life: " + enemy.GetComponent<AI>().life);
                           
                        }
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
            if (!aim)
            {
                Weapon.GetComponent<Animator>().Play("Recoil");
                yield return new WaitForSeconds(0.15f);
                Weapon.GetComponent<Animator>().Play("New State");
            }
            else
            {
                Weapon.GetComponent<Animator>().Play("AimRecoil");
                yield return new WaitForSeconds(0.15f);
                if (aim)
                {
                Weapon.GetComponent<Animator>().Play("AimIdle");
                }
                else
                {
                    Weapon.GetComponent<Animator>().Play("New State");
                }
            }
        }

        if (Weapon.tag == "Knife")
        {
            Weapon.GetComponent<Animator>().Play("KnifeAnimation");
            yield return new WaitForSeconds(0.3f);
            Weapon.GetComponent<Animator>().Play("New State");
        }
    }

}
