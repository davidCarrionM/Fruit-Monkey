using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject spawnCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CanvasSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CanvasSpawn()
    {
        spawnCanvas.GetComponent<Animator>().Play("respawn");
        yield return new WaitForSeconds(4f);
        spawnCanvas.GetComponent<Animator>().Play("New State");
        spawnCanvas.SetActive(false);
    }
}
