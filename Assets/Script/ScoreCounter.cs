﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    public int timeScore = 0;
    public int enemyScore = 0;

    public bool startCount = false;

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<GameManager>();
        InvokeRepeating("PerSecondScore", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        score = timeScore + enemyScore;
        scoreText.text = "Score: " + score;
        if (manager.playerDead == true)
        {
            CancelInvoke("PerSecondScore");
        }
    }
    void PerSecondScore()
    {
        if (startCount == true)
        {
            timeScore += 2;
        }
    }

    public void Reset()
    {
         InvokeRepeating("PerSecondScore", 1.0f, 1.0f);
         score = 0;
         timeScore = 0;
         enemyScore = 0;
    }

}