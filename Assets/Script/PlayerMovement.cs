using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float upMovement; // 6 is best 
    Rigidbody2D rb2d;

    AudioSource sound;

    PlayerDeath deathScript;
    public GameObject player;

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
        sound = GetComponent<AudioSource>();
        state = State.alive;
        deathMove = false;
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
                if (Input.GetKeyDown(KeyCode.Space))AliveMovement();
                break;
            case State.dead:
                DeadMovement();
                break;
        }
    }
    public void AliveMovement()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(transform.up * upMovement, ForceMode2D.Impulse);
        sound.Play();
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
