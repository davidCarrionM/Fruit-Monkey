using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class AI : MonoBehaviour
{
    //Añadir headers
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;
    public int life = 6;
    public float distanceDestination = 2f;
    private GameObject player = null;
    //public bool followPlayer;
    private float distanceToPlayer;
    public float distanceToFollow = 10;
    private Ragdoll ragdollScript;
    private float speedRunning;
    public float Range = 1f;
    public Transform RaycastPosition;
    private float speedNormal;
    public float ShotRate = 1f;
    private float shotRateTime = 0f;
    private Vector3[] vectores = new Vector3[9];
    public LayerMask playerMask;
    private bool auxManager = true;
    public AudioClip damageSound;
    System.Random random = new System.Random();
    void Start()
    {
        
        navMeshAgent.destination = destinations[random.Next(0, destinations.Length)].position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        ragdollScript = GetComponent<Ragdoll>();
        speedRunning = navMeshAgent.speed * 3;
        speedNormal = navMeshAgent.speed;
    }

    void Update()
    {
        if (!GameManager.Instance.pause)
        {
            vectores[0] = RaycastPosition.forward;
            vectores[1] = (RaycastPosition.forward + RaycastPosition.right);
            vectores[2] = (RaycastPosition.forward - RaycastPosition.right);

            vectores[3] = (RaycastPosition.forward + RaycastPosition.up);
            vectores[4] = (RaycastPosition.forward + RaycastPosition.right + RaycastPosition.up);
            vectores[5] = (RaycastPosition.forward - RaycastPosition.right + RaycastPosition.up);

            vectores[6] = (RaycastPosition.forward - RaycastPosition.up);
            vectores[7] = (RaycastPosition.forward + RaycastPosition.right - RaycastPosition.up);
            vectores[8] = (RaycastPosition.forward - RaycastPosition.right - RaycastPosition.up);
            if (life <= 0)
            {
                ragdollScript.ragdollDisable = true;
                ragdollScript.SetEnabled(ragdollScript.ragdollDisable);
                if (auxManager)
                {
                    GameManager.Instance.totalEnemies -= 1;
                    auxManager = false;
                }
                Destroy(this.transform.root.gameObject, 15);
            }
            else
            {
                for (int i = 0; i < vectores.Length - 1; i++)
                {


                    RaycastHit hit;
                    if (Physics.Raycast(RaycastPosition.position, vectores[i], out hit, Range, playerMask))
                    {
                        Debug.Log("Hit" + hit.collider.name);

                        if (hit.collider.gameObject.tag == "Player")
                        {
                            //Debug.Log("Vector Usado" + i);

                            if (Time.time > shotRateTime)
                            {
                                ControladorSonido.Instance.EjecutarSonido(damageSound);
                                GameManager.Instance.loseLife(10);
                                shotRateTime = Time.time + ShotRate;
                                player = hit.collider.gameObject;

                                player.GetComponent<PlayerMovement>().Damage();
                                break;
                            }
                        }
                    }
                }
            }
            if (!ragdollScript.ragdollDisable)
            {
                distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
                if (distanceToPlayer <= distanceToFollow)
                {
                    FollowPlayer();
                }
                else
                {
                    EnemyPath();
                }
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
        }
    }
    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;
        if (Vector3.Distance(transform.position, destinations[i].position) < distanceDestination)
        {
            i = random.Next(0, destinations.Length);
            //if (i < destinations.Length - 1)
            //{
            //    i++;
            //}
            //else
            //{
            //    i = 0;
            //}

        }
        navMeshAgent.speed = speedNormal;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(RaycastPosition.position, RaycastPosition.forward * Range);
        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward + RaycastPosition.right).normalized * Range);
        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward - RaycastPosition.right).normalized * Range);

        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward + RaycastPosition.up).normalized * Range);
        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward + RaycastPosition.right + RaycastPosition.up).normalized * Range);
        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward - RaycastPosition.right + RaycastPosition.up).normalized * Range);


        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward - RaycastPosition.up).normalized * Range);
        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward + RaycastPosition.right - RaycastPosition.up).normalized * Range);
        Gizmos.DrawRay(RaycastPosition.position, (RaycastPosition.forward - RaycastPosition.right - RaycastPosition.up).normalized * Range);

    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
        navMeshAgent.speed = speedRunning;
    }

}
