using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterControler;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGround;
    public float jumpHeigh = 3f;

    Vector3 velocity;
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);

        if (isGround && velocity.y <0)
        {
            velocity.y = -2f;
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
}