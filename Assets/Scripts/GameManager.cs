using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text fruitText;
    public static GameManager Instance { get; private set; }
    public int fruits = -1;

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
    }
}
