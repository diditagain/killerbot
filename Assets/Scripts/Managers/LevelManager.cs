using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] TextMeshProUGUI levelText;

    public Image killPercentage;
    public List<int> levels;
    public GameObject enemyPoolParent;
    public int currentLevel = 0;
    public float enemyRespawnTime;
    public int killedEnemy;



    int totalEnemy;
    EnemyPool[] enemyPools;



    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void Start()
    {
        FindTotalEnemy();
        levelText.text = "Level: " + currentLevel;
    }

    private void FindTotalEnemy()
    {
        int currentLevelEnemy = levels[currentLevel];
        enemyPools = enemyPoolParent.GetComponentsInChildren<EnemyPool>();
        int enemyPoolCount = enemyPools.Length;
        totalEnemy = enemyPoolCount * currentLevelEnemy;
        Debug.Log(enemyPoolCount);
    }

    private void NewLevel()
    {
        currentLevel++;
        levelText.text = "Level: " + currentLevel;
        killedEnemy = 0;
        FindTotalEnemy();
        foreach (EnemyPool enemyPool in enemyPools)
        {
            enemyPool.StartLevel();
        }
        killPercentage.fillAmount = 1;
    }

    public void EnemyKilled()
    {
        killedEnemy++;
        killPercentage.fillAmount -= 1f / totalEnemy;
        Debug.Log(1 / totalEnemy);
        if (killedEnemy >= totalEnemy)
        {

            NewLevel();
        }
    }
    


}
