using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip audioButon;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Jugar()
    {
        ControladorSonido.Instance.EjecutarSonido(audioButon);
        SceneManager.LoadScene("PrincipalGame");
    }

    public void Quitar()
    {
        ControladorSonido.Instance.EjecutarSonido(audioButon);
        Application.Quit();
    }

    public void Menu()
    {
        ControladorSonido.Instance.EjecutarSonido(audioButon);
        SceneManager.LoadScene("Menu");
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("PAUSE");
    }

    private void OnDisable()
    {
        ControladorSonido.Instance.Delete();
    }

}
