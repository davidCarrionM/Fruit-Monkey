using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text fruitText;
    public Text lifeText;
    public static GameManager Instance { get; private set; }
    public int fruits = -1;
    public int life = 100;

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
        fruitText.text = fruits.ToString()+"\n";
        lifeText.text = life.ToString()+"\n";
    }

    public void loseLife(int lifeToLose)
    {
        life-=lifeToLose;
    }
}
