using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int maxEnemies = 30;
    public int totalEnemies = 0;
    public float bomb = 0.0f;
    public bool pause = false;

    private void Start()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruit").Length;
        Debug.Log("Frutas Total: " + GameObject.FindGameObjectsWithTag("Fruit").Length);
        pause = false;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (fruits.ToString() != fruitText.text)
        {
            fruitText.text = fruits.ToString() + "\n";
        }
        if (life.ToString() != lifeText.text)
        {
            lifeText.text = life.ToString() + "\n";
        }
        if (bomb.ToString() != bombText.text)
        {
            if (bomb <= 0)
            {
                bombText.text = "!!!" + "\n";
            }
            else
            {
                bombText.text = bomb.ToString("0.#") + "\n";
            }
        }
        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (fruits <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void loseLife(int lifeToLose)
    {
        life -= lifeToLose;
    }
    

}
