using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool playerDead;
    public GameObject trail;

    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "TopBound")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            trail.active = false;
            playerDead = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerDead();
            sound.Play();
        }
    }

    public void Reset()
    {
      playerDead = false;
      trail.active = true;
      gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
