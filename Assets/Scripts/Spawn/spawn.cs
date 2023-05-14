using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class spawn : MonoBehaviour
{
    public float spawnRate = 5f;
    private float spawnRateTime = 0f;
    public Transform[] destinations;
    public GameObject[] fence;
    public GameObject cubeLocation;
    public GameObject enemy;
    public bool active = true;
    public GameObject explosionEffect;
    public bool broken = false;
    public int life = 3;
    private Renderer material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (broken)
            {
                if (fence.Length > 0)
                {
                    GameObject explosion = Instantiate(explosionEffect, fence[0].transform.position, fence[0].transform.rotation);
                    Destroy(explosion, 3);
                    foreach (var item in fence)
                    {
                        Destroy(item);
                    }
                }
                active = false;
            }
            else
            {
                if (GameManager.Instance.totalEnemies <= GameManager.Instance.maxEnemies)
                {

                    if (Time.time > spawnRateTime)
                    {
                        GameObject enemyAux = Instantiate(enemy, this.transform.position, this.transform.rotation);
                        GameManager.Instance.totalEnemies += 1;
                        enemyAux.GetComponent<AI>().destinations = destinations;
                        spawnRateTime = Time.time + spawnRate;
                    }
                    if (life < 3)
                    {
                        if (life == 2)
                        {
                            material.material.color = Color.green;
                        }
                        else
                        {
                            if (life == 1)
                            {
                                material.material.color = Color.red;
                            }
                            else
                            {
                                material.material.color = Color.black;
                                broken = true;
                            }
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
