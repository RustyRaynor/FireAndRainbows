using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laser;
    public GameObject spawn;
    //public GameObject sound;
    public AudioSource sound;

    float lastFire = 0;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        sound.Stop();
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
        if (Time.time >= lastFire)
        {
            lastFire = Time.time + fireRate;
            Vector2 spawnPosition = new Vector2(spawn.transform.position.x, spawn.transform.position.y);
            Instantiate(laser, spawnPosition, spawn.transform.rotation);
            sound.Play();
        }
    }
}