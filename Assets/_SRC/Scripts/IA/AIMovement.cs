using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    [Header("Enemy Info")]
    public float attackRange;
    public float attackSpeed;
    public float currentAttackCooldown;
    public int[] AttackDamage;
    public bool canAttack;


    [Header("Player Info")]
    public Transform player;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Chase();
        
        if (canAttack)
        {
            Attack();
        }
        else
        {
            currentAttackCooldown -= Time.deltaTime;

            if (currentAttackCooldown <= 0)
            { 
                canAttack = true;
                currentAttackCooldown = attackSpeed;
            }
        }
    }
    void Attack()
    {
        canAttack = false;

        player.GetComponent<IDamageble>().TakeDamage(Random.Range(AttackDamage[0], AttackDamage[1]));
    }
    void Chase()
    {
        nav.SetDestination(player.position);
    }
    
}
