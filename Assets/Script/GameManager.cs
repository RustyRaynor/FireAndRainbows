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
    [SerializeField]Transform movablesParent;
    
    void Start()
    {
        spawnX = Screen.width/10 + Screen.width;
        SpawnPlayer();
    }

    void Update()
    {
        scrollAmount = Time.deltaTime * scrollSpeed;
        scrollValue += scrollAmount;
        if(scrollValue > nextSpawnPoint)SpawnObstacles();
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width/4, Screen.height/2, 1));
        Instantiate(playerObj, pos, Quaternion.identity);
    }



    void SpawnObstacles()
    {
        float yVal = Random.Range(3, 10) * Screen.height/10;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, yVal, 1));
        SpawnableStaticObjectData spawnableObj = stageList[currentStage].GetObject();
        GameObject obj = Instantiate(spawnableObj.spawnableObject, pos, Quaternion.identity, movablesParent);

        nextSpawnPoint = scrollValue + spawnableObj.intervel;
    }

}
