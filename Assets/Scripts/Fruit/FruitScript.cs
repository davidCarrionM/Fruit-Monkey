using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject[] myFruits;
    public float size = 2.5f;
    private GameObject fruit;
    public GameObject Effect;
    public AudioClip fuitSound;
    public AudioClip monkeySound;

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
            ControladorSonido.Instance.EjecutarSonido(monkeySound);
            
            ControladorSonido.Instance.EjecutarSonido(fuitSound);
            GameManager.Instance.fruits -= 1;
            if (GameManager.Instance.life < 100)
            {
                GameManager.Instance.life += 5;
            }
            GameObject efecto = Instantiate(Effect, gameObject.transform.position, Quaternion.identity);
            Destroy(efecto, 5);
            Destroy(transform.parent.gameObject);
        }
    }
}
