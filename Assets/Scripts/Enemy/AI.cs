using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //Añadir headers
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    private int i = 0;
    public float distanceDestination = 2f;
    private GameObject player;
    //public bool followPlayer;
    private float distanceToPlayer;
    public float distanceToFollow = 10;
    private Ragdoll ragdollScript;
    void Start()
    {
        navMeshAgent.destination = destinations[0].position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        ragdollScript = GetComponent<Ragdoll>();
    }

    void Update()
    {
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
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
