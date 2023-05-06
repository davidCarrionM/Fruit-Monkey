using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Añadir Headers

    public CharacterController characterControler;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGround;
    public bool isClimbing;
    public float jumpHeigh = 3f;
    public Animator Animator;
    public WeaponSwitch weaponSwitch;
    Vector3 velocity;
    //***********
    public Camera cam;
    private Camera camReference;
    //***********
    public GameObject damageCanvas;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 1.5f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = speed / 2.2f;
            transform.localScale = new Vector3(1f,0.5f,1f);
            cam.transform.localScale = new Vector3(1f,2f,1f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = speed * 2.2f;
            transform.localScale = new Vector3(1f, 1f, 1f);
            cam.transform.localScale = new Vector3(1f,1f,1f);
        }
        if (!isClimbing)
        {
            
            isGround = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

            if (isGround && velocity.y < 0)
            {
                velocity.y = -2f;
                velocity.x = 0;
                velocity.z = 0;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            if (isGround && Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpHeigh * -2 * gravity);
            }

            characterControler.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            characterControler.Move(velocity * Time.deltaTime);
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isClimbing = false;
                velocity.y = Mathf.Sqrt(jumpHeigh * -2 * gravity);
                isGround = true;
            }
        }

    }
    public void Damage()
    {
        StartCoroutine(DamageA());
        StartCoroutine(DamageCanvasA());
    }

    IEnumerator DamageA()
    {
        cam.GetComponent<Animator>().Play("Damage");
        yield return new WaitForSeconds(0.40f);
        cam.GetComponent<Animator>().Play("New State");
    }
    IEnumerator DamageCanvasA()
    {
        damageCanvas.GetComponent<Animator>().Play("DamageCanvas");
        yield return new WaitForSeconds(0.40f);
        damageCanvas.GetComponent<Animator>().Play("New State");
    }
}
