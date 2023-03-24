using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public float range = 1f;
    public Camera Cam;
    public LayerMask layermask;
    public CharacterController characterControler;
    public PlayerMovement playerMovement;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range, layermask))
            {
                Debug.Log(hit.transform.name);

                velocity.y = playerMovement.speed/2.5f;
                characterControler.Move(velocity * Time.deltaTime);

                playerMovement.isClimbing = true;
            }
            else
            {
                playerMovement.isClimbing = false;
            }
        }
    }

}