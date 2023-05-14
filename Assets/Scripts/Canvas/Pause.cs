using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menuPausa;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pausa();
        }
    }

    public void Pausa()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0.0f;
        menuPausa.SetActive(true);
        GameManager.Instance.pause = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        menuPausa.SetActive(false);
        GameManager.Instance.pause = false;

    }
}
