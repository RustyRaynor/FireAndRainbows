using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeaderboardRaw : MonoBehaviour {

    [SerializeField] private Color normalBoxColor;
    [SerializeField] private Color specialBoxColor;
    [SerializeField] private Text nameText;
    [SerializeField] private Text scoreText;


    public void SetInfo(string sendName, string sendScore, bool isMe)
    {
        nameText.text = sendName;
        scoreText.text = sendScore;
        if (isMe)
        {
            this.GetComponent<Image>().color = specialBoxColor;
        }
        else
        {
            this.GetComponent<Image>().color = normalBoxColor;
        }
    }

}
