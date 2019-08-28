using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerDeath deathScript;
    public GameObject player;

    ScoreCounter score;
    Statemanager stage;

    public AudioSource music;

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
    public Transform allEnemyHolder;
    public static Transform enemyHolder;

    [Header("Spwan Control")]
    public static bool canSpawn;
    [SerializeField]Transform movablesParent;
    bool gameOnPlay;
    
    public GameObject playerUni;
    public GameObject mainMenu;
    public GameObject gameMenu;
    public GameObject gameFinish;

    bool Run;
    bool initialize;

    public PlayFabLeaderBoard playFabLeaderBoard;
    public ScoreCounter scoreCounter;
    public Text ScoreDisplay;


    void Start()
    {
        enemyHolder = allEnemyHolder;
        gameOnPlay = true;
        canSpawn = true;
        spawnX = Screen.width/10 + Screen.width;
        playerDead = false;
        Run = false;
        SpawnPlayer();
        deathScript = player.GetComponent<PlayerDeath>();
        score = GetComponent<ScoreCounter>();
        stage = GetComponent<Statemanager>();

        music.Play();
    }

    public void StartGame()
    {
        Run = true;
        playerUni.SetActive(true);
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);
        initialize = true;
        score.startCount = true;
    }

    void Update()
    {
        if(playerDead  == true)
        {
            music.Stop();
        }

        if(Run){

            canStop = playerDead;

            if(gameOnPlay && currentStage >= stageList.Length)
            {
                gameOnPlay = false;
            }
            
            if(gameOnPlay)
            {
                scrollAmount = Time.deltaTime * scrollSpeed;
                scrollValue += scrollAmount;
                if(playerDead == false)
                {
                    if(canSpawn)
                    {
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
        }
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3( Screen.width/6, Screen.height/2, 1));
        playerUni = Instantiate(playerObj, pos, Quaternion.identity);
        playerUni.SetActive(false);
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

    public void PlayerDead()
    {
        gameMenu.SetActive(false);
        playerDead = true;
        Run = false;
        ScoreDisplay.text = scoreCounter.enemyScore.ToString();
        playFabLeaderBoard.StartCloudUpdatePlayerStats(scoreCounter.enemyScore);
        StartCoroutine("EndScreen");
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(3);
        gameFinish.SetActive(true);
    }

    public void UnicornJump()
    {
        playerUni.GetComponent<PlayerMovement>().AliveMovement();
    }

    public void UnicornShoot()
    {
        playerUni.GetComponent<PlayerShoot>().Shoot();
    }

    public void Reset()
    {
        music.Play();

        allEnemyHolder.gameObject.SetActive(false);
        Transform[] allEnemies = allEnemyHolder.gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allEnemies.Length; i++)
        {
            if(allEnemies[i] != allEnemyHolder)Destroy(allEnemies[i].gameObject);
        }

        allEnemyHolder.gameObject.SetActive(true);
        canSpawn = true;
      scoreCounter.Reset();
      Destroy(playerUni);
        SpawnPlayer();
       playerUni.SetActive(true);
       score.timeScore = 0;
       score.enemyScore = 0;
       currentStage = 0;
       enemyWaves = 0;

        gameOnPlay = true;

        gameMenu.SetActive(true);

        playerDead = false;
        Run = true;
        gameFinish.SetActive(false);
        stage.bossDefeated = 0;
    } 

}