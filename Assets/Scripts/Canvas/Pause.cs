using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject blackscreen;
    public GameObject redScreen;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        menuPausa.SetActive(false);
        blackscreen.SetActive(true);
        redScreen.SetActive(true);
        GameManager.Instance.pause = false;
    }

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
        blackscreen.SetActive(false);
        redScreen.SetActive(false);
        GameManager.Instance.pause = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        menuPausa.SetActive(false);
        blackscreen.SetActive(true);
        redScreen.SetActive(true);
        GameManager.Instance.pause = false;

    }
    public void Menu()
    {
        blackscreen.SetActive(true);
        redScreen.SetActive(true);
        GameManager.Instance.pause = false;
        SceneManager.LoadScene("Menu");
    }

    public void Quitar()
    {
        Application.Quit();
    }
}
