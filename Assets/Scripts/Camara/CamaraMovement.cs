using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public float Sensibility = 80f;
    public Transform PlayerBody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!GameManager.Instance.pause)
        {
            float mouseX = Input.GetAxis("Mouse X") * Sensibility * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensibility * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
