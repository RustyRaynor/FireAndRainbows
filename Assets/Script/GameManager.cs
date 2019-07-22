using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerObj;

    void Start()
    {
        SpawnPlayer();
    }

    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/3, Screen.height/2, 1));
        Instantiate(playerObj, pos, Quaternion.identity);
    }

}
