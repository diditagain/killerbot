using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform coverPos; 

    LevelManager levelManager;
    List<EnemyBehaviorScript> enemyList = new List<EnemyBehaviorScript>();
    float currentTime;
    float spawnWaitTime = 2f;
    int enemyNum;
    int respawnedEnemyCount = 0;


    private void Start()
    {
        levelManager = LevelManager.instance;
        CreateEnemyPool();
        StartLevel();
    }

    private void Update()
    {
        RespawnEnemies();
    }


    void CreateEnemyPool()
    {
        int poolSize = 100;
        for (int i = 0; i <= poolSize; i++)
        {
            GameObject tempEnemy = Instantiate(enemyPrefab);
            tempEnemy.transform.parent = this.transform;
            tempEnemy.transform.localPosition = Vector3.zero;
            tempEnemy.GetComponent<EnemyBehaviorScript>().coverPos = coverPos.transform;
            tempEnemy.SetActive(false);
            enemyList.Add(tempEnemy.GetComponent<EnemyBehaviorScript>());
        }
    }

    void RespawnEnemies()
    {
        while (Time.time >= currentTime + spawnWaitTime && respawnedEnemyCount < enemyNum)
        {
            enemyList[respawnedEnemyCount].gameObject.SetActive(true);
            respawnedEnemyCount++;
            currentTime = Time.time;
        }
    }

    public void StartLevel()
    {
        currentTime = Time.time;
        respawnedEnemyCount = 0;
        enemyNum = levelManager.levels[levelManager.currentLevel];
    }
}
