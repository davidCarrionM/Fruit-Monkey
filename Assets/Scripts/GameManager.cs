using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }

    public int fruits = -1;

    private void Start()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruit").Length;
    }

    private void Awake()
    {
        Instance = this; 
    }
}
