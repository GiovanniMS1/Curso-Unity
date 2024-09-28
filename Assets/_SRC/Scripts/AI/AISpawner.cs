using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public EnemyScriptable[] enemiesBrains;
    public GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 1);
    }
    public void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<AIController>().Init(enemiesBrains[Random.Range(0, enemiesBrains.Length)]);
    }
}
