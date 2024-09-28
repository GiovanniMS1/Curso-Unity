using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public EnemyScriptable[] enemyScriptable;
    public GameObject enemyPrefab;
    public void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<AIController>().Init();
    }
}
