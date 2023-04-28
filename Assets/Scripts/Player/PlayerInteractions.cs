using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("NO DESTRUYE FRUTA");

        if (other.gameObject.CompareTag("Fruit"))
        {
            Debug.Log("DESTRUYE FRUTA");
            Destroy(other.gameObject);
        }
    }
}
