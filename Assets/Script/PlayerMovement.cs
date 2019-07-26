using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float upMovement; // 6 is best 
    Rigidbody2D rb2d;
    public GameObject laser;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        } 
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(transform.up * upMovement, ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        Vector2 spawnPosition = new Vector2(spawn.transform.position.x, spawn.transform.position.y);
        Instantiate(laser, spawnPosition, spawn.transform.rotation);
    }
}
