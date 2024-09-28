using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICombat : MonoBehaviour
{
    private EnemyScriptable brain;

    [Header("Attack Info")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;

    private NavMeshAgent nav;

    public void Init(EnemyScriptable pBrain)
    {
        brain = pBrain;

        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = brain.AttackRange;
    }
    public bool CheckAttack(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) < brain.AttackRange)
        {
            if (canAttack)
            {
                Attack(target);
            }

            return true;
        }

        return false;
    }

    public void CooldownRecover()
    {
        currentAttackCooldown -= Time.deltaTime;

        if (currentAttackCooldown <= 0)
        {
            canAttack = true;
            currentAttackCooldown = brain.attackSpeed;
        }
    }

    void Attack(Transform target)
    {
        canAttack = false;

        target.GetComponent<IDamageable>().TakeDamage(Random.Range(brain.AttackDamage[0], brain.AttackDamage[1]));
    }
}
