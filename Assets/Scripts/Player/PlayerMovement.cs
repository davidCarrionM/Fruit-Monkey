using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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

    Vector3 velocity;
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
            //if (z!=0 || x != 0)
            //{
            //    Animator.SetBool("isMoving", true);
            //}
            //else
            //{
            //    Animator.SetBool("isMoving", false);

            //}
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

}
