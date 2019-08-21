using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerDeath deathScript;
    public GameObject player;

    public bool playerDead;

    public static bool canStop;

    [Header("Player Control")]
    public GameObject playerObj;
    public static float scrollAmount;
    public static float scrollValue;
    public float scrollSpeed;

    [Header("Stage Control")]
    public Stage[] stageList;
    float spawnX;
    [SerializeField] int currentStage, enemyWaves;

    [Header("Spwan Control")]
    public static bool canSpawn;
    [SerializeField]Transform movablesParent;
    bool gameOnPlay;
    
    void Start()
    {
        gameOnPlay = true;
        canSpawn = true;
        spawnX = Screen.width/10 + Screen.width;
        playerDead = false;
        SpawnPlayer();
        deathScript = player.GetComponent<PlayerDeath>();
    }

    void Update()
    {
        canStop = playerDead;

        if(gameOnPlay && currentStage >= stageList.Length){
            EndGame();
            gameOnPlay = false;
        }
        
        scrollAmount = Time.deltaTime * scrollSpeed;
        scrollValue += scrollAmount;
        if(playerDead == false){
            if(canSpawn){
                if(enemyWaves < stageList[currentStage].maxWaves)SpawnEnemy();
                else if(enemyWaves == stageList[currentStage].maxWaves)SpawnBoss();
                else if(enemyWaves > stageList[currentStage].maxWaves)StartNewStage();
            }
        }
        else
        {
            scrollSpeed = 0;
        }
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width/6, Screen.height/2, 1));
        Instantiate(playerObj, pos, Quaternion.identity);
    }

    void SpawnEnemy()
    {
        stageList[currentStage].SpawnEnemies();
        enemyWaves++;
        canSpawn = false;
    }

    void SpawnBoss()
    {
        stageList[currentStage].SpawnBoss();
        enemyWaves++;
        canSpawn = false;
    }

    void StartNewStage()
    {
        currentStage++;
        enemyWaves = 0;
    }

    void EndGame()
    {

    }

}