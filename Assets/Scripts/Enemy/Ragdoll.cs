using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody[] rigidbodies;
    public bool ragdollDisable;

    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        ragdollDisable = false;
        SetEnabled(ragdollDisable);
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        animator.enabled = !enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ragdollDisable = true;
            SetEnabled(ragdollDisable);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ragdollDisable = false;
            SetEnabled(ragdollDisable);
        }
    }
}