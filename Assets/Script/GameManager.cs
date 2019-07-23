using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Control")]
    public GameObject playerObj;
    public static float scrollValue;
    public float scrollSpeed;
    [Header("Enemy Control")]
    public GameObject[] enemyObjs;
    public float rateCtrl = 2;
    float spawnX;
    [SerializeField]float nextSpawnTime;
    

    void Start()
    {
        spawnX = Screen.width/10 + Screen.width;
        SpawnPlayer();
    }

    void Update()
    {
        scrollValue = Time.deltaTime * scrollSpeed;
        if(Time.time > nextSpawnTime)SpawnEnemies();
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width/4, Screen.height/2, 1));
        Instantiate(playerObj, pos, Quaternion.identity);
    }

    void SpawnEnemies()
    {
        float yVal = Random.Range(1, 9) * Screen.height/10;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, yVal, 1));
        GameObject obj = Instantiate(enemyObjs[0], pos, Quaternion.identity);

        nextSpawnTime = Time.time + 1/rateCtrl;
    }

}
