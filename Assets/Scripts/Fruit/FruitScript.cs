using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject[] myFruits;
    public float size = 2.5f;
    private GameObject fruit;
    public GameObject Effect;

    void Start()
    {
        int randomIndex = Random.Range(0, myFruits.Length);
        fruit = Instantiate(myFruits[randomIndex], this.transform.position, Quaternion.identity);
        fruit.transform.localScale = new Vector3(size,size,size);
        fruit.transform.parent = gameObject.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.fruits -= 1;
            GameObject efecto = Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            Destroy(efecto, 5);
            Destroy(transform.parent.gameObject);
        }
    }
}
