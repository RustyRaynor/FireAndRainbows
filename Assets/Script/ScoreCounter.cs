using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    int timeScore = 0;
    public int enemyScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PerSecondScore", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        score = timeScore + enemyScore;
        scoreText.text = "Score: " + score;
    }

    void PerSecondScore()
    {
        timeScore += 2;
    }
}
