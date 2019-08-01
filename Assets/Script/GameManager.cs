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

    [Header("Spwan Control")]
    public static bool canSpawn;
    [SerializeField]Transform movablesParent;
    
    void Start()
    {
        canSpawn = true;
        spawnX = Screen.width/10 + Screen.width;
        SpawnPlayer();
    }

    void Update()
    {
        scrollAmount = Time.deltaTime * scrollSpeed;
        scrollValue += scrollAmount;

        if(canSpawn)SpawnEnemy();
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width/4, Screen.height/2, 1));
        Instantiate(playerObj, pos, Quaternion.identity);
    }

    void SpawnEnemy()
    {
        stageList[currentStage].SpawnEnemies();
        canSpawn = false;
    }

}
