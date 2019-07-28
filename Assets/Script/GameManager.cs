using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Control")]
    public GameObject playerObj;
    public static float scrollAmount;
    public static float scrollValue;
    public float scrollSpeed;

    [Header("Stage Control")]
    public Stage[] stageList;
    float spawnX;
    int currentStage;
    
    [SerializeField]float nextSpawnPoint;
    [SerializeField] GameObject enemyTestObj;
    [SerializeField]float nextEnemySpawnPoint;
    [SerializeField]Transform movablesParent;

    public bool enemySpawnState;
    public int enemySpawnPeriod;
    
    void Start()
    {
        nextEnemySpawnPoint = 10;
        spawnX = Screen.width/10 + Screen.width;
        SpawnPlayer();
    }

    void Update()
    {
        scrollAmount = Time.deltaTime * scrollSpeed;
        scrollValue += scrollAmount;

        if(enemySpawnState){
            if(scrollValue > nextEnemySpawnPoint)SpawnEnemy();
            }

        else {
            if(scrollValue > nextSpawnPoint)SpawnObstacles();
            }

        if(scrollValue > enemySpawnPeriod)
        {
            enemySpawnPeriod = (int)scrollValue + Random.Range(30, 150);
            enemySpawnState = (Random.Range(0, 10) > 5) ? true : false;
        }
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width/4, Screen.height/2, 1));
        Instantiate(playerObj, pos, Quaternion.identity);
    }



    void SpawnObstacles()
    {
        float yVal = Random.Range(3, 10) * Screen.height/10;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, yVal, 2));
        SpawnableStaticObjectData spawnableObj = stageList[currentStage].GetObject();
        GameObject obj = Instantiate(spawnableObj.spawnableObject, pos, Quaternion.identity, movablesParent);

        nextSpawnPoint = scrollValue + spawnableObj.intervel;
    }

    void SpawnEnemy()
    {
        nextEnemySpawnPoint = scrollValue + stageList[currentStage].SpawnEnemies();
    }

}
