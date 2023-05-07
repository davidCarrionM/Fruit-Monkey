using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform spawnPosition;
    public Transform spawnSpikesTuto;
    public GameObject spawnCanvas;

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("DeathFloor"))
        {
            GameManager.Instance.loseLife(5);

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawnPosition.position;
            GetComponent<CharacterController>().enabled = true;
            StartCoroutine(CanvasSpawn());
        }
        if (other.gameObject.CompareTag("SpikesTuto"))
        {
            GameManager.Instance.loseLife(5);

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawnSpikesTuto.position;
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
