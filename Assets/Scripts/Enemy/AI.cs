using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class AI : MonoBehaviour
{
    //A�adir headers
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;
    public int life = 6;
    public float distanceDestination = 2f;
    private GameObject player;
    //public bool followPlayer;
    private float distanceToPlayer;
    public float distanceToFollow = 10;
    private Ragdoll ragdollScript;
    private float speedRunning;
    private float speedNormal;
    void Start()
    {
        navMeshAgent.destination = destinations[0].position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        ragdollScript = GetComponent<Ragdoll>();
        speedRunning = navMeshAgent.speed * 3;
        speedNormal = navMeshAgent.speed;
    }

    void Update()
    {
        if (life <=0 ) {
            ragdollScript.ragdollDisable = true;
            ragdollScript.SetEnabled(ragdollScript.ragdollDisable);
                Destroy(this.transform.root.gameObject,45);
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

    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;
        if (Vector3.Distance(transform.position, destinations[i].position) < distanceDestination)
        {
            if (i < destinations.Length - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }

        }
        navMeshAgent.speed = speedNormal;

    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
        navMeshAgent.speed = speedRunning;
    }
}