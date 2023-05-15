using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform spawnPosition;
    public Transform spawnSpikesTuto;
    public Transform spawnWater;
    public GameObject spawnCanvas;
    public AudioClip damageSound;

    private void Start()
    {
        StartCoroutine(CanvasSpawn());
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("DeathFloor"))
        {
            ControladorSonido.Instance.EjecutarSonido(damageSound);
            GameManager.Instance.loseLife(5);
            Debug.Log("DEATH FLOOR");
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawnPosition.position;
            GetComponent<CharacterController>().enabled = true;
            StartCoroutine(CanvasSpawn());
        }
        if (other.gameObject.CompareTag("SpikesTuto"))
        {
            ControladorSonido.Instance.EjecutarSonido(damageSound);

            GameManager.Instance.loseLife(5);
            Debug.Log("SPIKES FLOOR");
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawnSpikesTuto.position;
            GetComponent<CharacterController>().enabled = true;
            StartCoroutine(CanvasSpawn());
        }
        if (other.gameObject.CompareTag("WaterFloor"))
        {
            ControladorSonido.Instance.EjecutarSonido(damageSound);

            GameManager.Instance.loseLife(5);
            Debug.Log("WATER FLOOR");
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawnWater.position;
            GetComponent<CharacterController>().enabled = true;
            StartCoroutine(CanvasSpawn());
        }
    }

    IEnumerator CanvasSpawn()
    {

        spawnCanvas.GetComponent<Animator>().Play("respawn");
        yield return new WaitForSeconds(4f);
        spawnCanvas.GetComponent<Animator>().Play("New State");
    }

    
}
