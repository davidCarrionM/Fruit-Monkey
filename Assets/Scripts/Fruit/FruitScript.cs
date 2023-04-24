using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject[] myFruits;
    public float size = 2.5f;
    private GameObject fruit;

    void Start()
    {
        int randomIndex = Random.Range(0, myFruits.Length);
         fruit = Instantiate(myFruits[randomIndex], this.transform.position, Quaternion.identity);
        fruit.transform.localScale = new Vector3(size,size,size);
        fruit.transform.parent = gameObject.transform;
        StartCoroutine(animation());
    }
    IEnumerator animation()
    {
                this.GetComponent<Animator>().Play("FruitAnimation");
                yield return new WaitForSeconds(1.2f);
                this.GetComponent<Animator>().Play("New State");
    }
}
