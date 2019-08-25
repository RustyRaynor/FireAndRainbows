using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float upMovement; // 6 is best 
    Rigidbody2D rb2d;

    PlayerDeath deathScript;
    public GameObject player;

    Renderer rend;

    bool deathMove;

    enum State
    {
        alive,
        dead
    }
    State state;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        deathScript = player.GetComponent<PlayerDeath>();
        rend = GetComponent<Renderer>();
        state = State.alive;
        deathMove = false;
        rend.material.shader = Shader.Find("TranyHorse");
    }

    void Update()
    {
        if (deathScript.playerDead == true)
        {
            state = State.dead;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.alive:
                //rend.material.SetFloat("_Shift", 2);
                AliveMovement();
                break;
            case State.dead:
                DeadMovement();
                break;
        }
    }
    public void AliveMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(transform.up * upMovement, ForceMode2D.Impulse);
        }
    }
    void DeadMovement()
    {
       if (deathMove == false)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(transform.up * 30, ForceMode2D.Impulse);
            rb2d.AddTorque(100000f);
            rb2d.gravityScale = 5;
            deathMove = true;
        }
    }
}
