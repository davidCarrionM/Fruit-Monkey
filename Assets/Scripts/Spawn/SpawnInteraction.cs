using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteraction : MonoBehaviour
{
    public GameObject father;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (!father.GetComponent<spawn>().broken)
            {
                father.GetComponent<spawn>().active = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!father.GetComponent<spawn>().broken)
            {
                father.GetComponent<spawn>().active = false;
            }
        }
    }
}
