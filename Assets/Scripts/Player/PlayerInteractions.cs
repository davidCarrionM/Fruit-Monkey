using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform spawnPosition;

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

        }
    }
}
