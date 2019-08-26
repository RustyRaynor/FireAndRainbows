using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laser;
    public GameObject spawn;
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Vector2 spawnPosition = new Vector2(spawn.transform.position.x, spawn.transform.position.y);
        Instantiate(laser, spawnPosition, spawn.transform.rotation);
        sound.SetActive(true);
    }
}