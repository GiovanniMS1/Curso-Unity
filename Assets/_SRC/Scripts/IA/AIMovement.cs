using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent nav;

    public float currentAttackCooldown;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    public void Chase(Transform target)
    {
        if (!target) return;

        nav.SetDestination(target.position);
    }
}
