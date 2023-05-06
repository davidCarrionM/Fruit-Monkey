using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Text fruitText;
    public Text lifeText;
    public Text bombText;

    public static GameManager Instance { get; private set; }
    public int fruits = -1;
    public int life = 100;
    public float bomb = 0.0f;

    private void Start()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruit").Length;
        Debug.Log("Frutas Total: "+ GameObject.FindGameObjectsWithTag("Fruit").Length);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (fruits.ToString() != fruitText.text)
        {
            fruitText.text = fruits.ToString()+"\n";
        }
        if (life.ToString() != lifeText.text)
        {
            lifeText.text = life.ToString() + "\n";
        }
        if (bomb.ToString() != bombText.text) {

        if (bomb <= 0)
        {
            bombText.text = "!!!" + "\n";
        }
        else
        {
            bombText.text =  bomb.ToString("0.#") + "\n";
        }

        }
    }

    public void loseLife(int lifeToLose)
    {
        life-=lifeToLose;
    }
}
