using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] int maxEnemy = 10;
    [SerializeField] int enemyCount = 0;
    [SerializeField] float spawnInterval = 10f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;


    IEnumerator SpwanEnemyCO()
    {
        while(enemyCount < maxEnemy)
        {
            int i = R.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[i];
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            enemy.name = $"Enemy_{enemyCount}";

            enemyCount++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //Event Handlers
    private void OnEnable()
    {
        CountDownController.OnCountDownDone += StartSpawningEnemies;
    }

    private void OnDisable()
    {
        CountDownController.OnCountDownDone -= StartSpawningEnemies;
    }

    private void StartSpawningEnemies()
    {
        enemyCount = 0;
        StartCoroutine("SpwanEnemyCO");
    }
}
