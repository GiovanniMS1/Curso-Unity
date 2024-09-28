using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyData", order = 0)]
public class EnemyScriptable: ScriptableObject
{
    [Header("Status")]
    public Status status;

    [Header("Combat Data")]
    public float AttackRange;
    public float attackSpeed;
    public int[] AttackDamage;

    [Header("Graphics")]
    public GameObject GFX;
}

