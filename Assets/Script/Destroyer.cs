using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] bool spawnOnDeath;
    [SerializeField] float destroyOffset;

    float limitWorldX;

    void Start()
    {
        limitWorldX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x + destroyOffset < -limitWorldX)
        {
            Destroy(gameObject);
            if(spawnOnDeath) GameManager.canSpawn = true;
        }
    }
}
