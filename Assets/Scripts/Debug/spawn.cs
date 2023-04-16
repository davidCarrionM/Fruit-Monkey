using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float spawnRate = 5f;
    private float spawnRateTime = 0f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnRateTime)
        {
            Instantiate(enemy, this.transform.position, this.transform.rotation);
            spawnRateTime = Time.time + spawnRate;
        }
    }
}
